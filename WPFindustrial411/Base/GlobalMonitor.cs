using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFindustrial411.BLL;
using WPFindustrial411.Model;
using Ykx.Commucation;
using Ykx.Commucation.Modbus;

namespace WPFindustrial411.Base
{
    public class GlobalMonitor
    {
        public static List<StorageModel> StorageList { get; set; }
        public static List<DeviceModel> DeviceList { get; set; }
        public static SerialInfo SerialInfo { get; set; }

        static bool isRunning = true;
        static Task mainTask = null;
        static RTU rtuInstance=null;
        public static void Start(Action successAction,Action<string> faultAction)
        {
            //主线程启动
            mainTask=Task.Run(async() =>
            {
                IndustrialBLL bll = new IndustrialBLL();
                //获取串口配置信息
                var si=bll.InitSerialInfo();
                if (si.State)
                {
                    SerialInfo = si.Data;
                }
                else
                {
                    faultAction(si.Message);
                    return;
                }

                //获取存储区信息
                var sa = bll.InitStorageArea();
                if (sa.State)
                {
                    StorageList=sa.Data;
                }
                else
                {
                    faultAction(sa.Message);
                    return;
                }

                //初始化设备变量集合及警戒值
                var dr = bll.InitDevices();
                if (dr.State)
                {
                    DeviceList=dr.Data;
                }
                else
                {
                    faultAction(dr.Message);
                    return;
                }


                //初始化串口通信
                rtuInstance = RTU.GetInstance(SerialInfo);
                rtuInstance.ResponseData = new Action<int,List<byte>>(ParsingData);
                if (rtuInstance.Connection())
                {
                    successAction();

                    int startAddr = 0;
                    while (isRunning)
                    {
                        foreach (var item in StorageList)
                        {
                            //Modbus官方最大读取长度为125,这里可以写100
                            if (item.Length > 100)
                            {
                                startAddr = item.StartAddress;
                                int readCount = item.Length / 100;
                                for (int i = 0; i < readCount; i++)
                                {
                                    int readLen = i == readCount ? item.Length - 100 * i : 100;
                                    await rtuInstance.Send(item.SlaveAddress, (byte)int.Parse(item.FunCode), startAddr + 100 * i, readLen);
                                }
                            }

                            if (item.Length % 100 > 0)
                            {
                                await rtuInstance.Send(item.SlaveAddress, (byte)int.Parse(item.FunCode), startAddr + 100 * (item.Length / 100), item.Length%100);
                            }
                        }
                    }
                }
                else
                {
                    faultAction("程序无法启动，串口连接初始化失败！请检查连接是否正常。");
                }

            });
        }

        private static void ParsingData(int start_addr, List<byte> byteList)
        {
            if(byteList != null && byteList.Count > 0)
            {
                //查找设备监控点位与当前返回报文相关的监控数据列表
                //根据从站地址、功能码、起始地址
                var mvl=(from q in DeviceList
                         from m in q.MonitorValueList
                         where m.StorageAreaId==(byteList[0].ToString()+byteList[1].ToString("00")+start_addr.ToString())
                         
                         select m
                         ).ToList();

                int startByte;
                byte[] res = null;
                foreach(var item in mvl)
                {
                    switch (item.DataType)
                    {
                        case "Float":
                            startByte = item.StartAddress * 2 + 3;
                            if (startByte < start_addr + byteList.Count)
                            {
                                res = new byte[4]{ byteList[startByte], byteList[startByte + 1] ,byteList[startByte + 2],byteList[startByte + 3]};
                                item.CurrentValue = Convert.ToDouble(res.ByteArrayToFloat());
                            }
                            break;
                        case "bool":
                            break;
                    }
                }
            }
        }


        public static void Dispose()
        {
            isRunning = false;
            if(rtuInstance != null)
            {
                rtuInstance.Dispose();
            }
            if (mainTask != null)
            {
                mainTask.Wait();
            }
        }
    }
}
