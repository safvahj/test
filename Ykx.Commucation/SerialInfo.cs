using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ykx.Commucation
{
    public class SerialInfo
    {
        //串口号
        public string SerialPortName { get; set; } = "COM1";

        //波特率
        public int BaudRate { get; set; } = 9600;

        //数据位
        public int DataBit { get; set; } = 8;

        //下个serial io ports NuGet程序包
        //奇偶校验位
        public Parity Parity { get; set; } = Parity.None;

        //停止位
        public StopBits StopBits { get; set; } = StopBits.One;
    }
}
