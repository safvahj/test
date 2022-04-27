using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFindustrial411.Base;

namespace WPFindustrial411.Model
{
    public class MonitorValueModel
    {
        public Action<MonitorValueState, string,string> ValueStateChanged;
        public string ValueId { get; set; }
        public string ValueName { get; set; }
        public string StorageAreaId { get; set; }
        public int StartAddress { get; set; }
        public string DataType { get; set; }
        public bool IsAlarm { get; set; }
        public double LoLoAlarm { get; set; }
        public double LowAlarm { get; set; }
        public double HighAlarm { get; set; }
        public double HiHiAlarm { get; set; }
        //单位
        public string Unit { get; set; }
        private double _currentValue;
        public double CurrentValue
        {
            get { return _currentValue; }
            set 
            { 
                _currentValue = value;
                if (IsAlarm)
                {
                    string msg = ValueDesc;
                    MonitorValueState state = MonitorValueState.OK;
                    if (value < LoLoAlarm)
                    {
                        msg += "极低";
                        state = MonitorValueState.LoLo;
                    }
                    else if (value < LowAlarm)
                    {
                        msg += "过低";
                        state = MonitorValueState.Low;
                    }
                    else if(value > HiHiAlarm)
                    {
                        msg += "极高";
                        state= MonitorValueState.HiHi;
                    }
                    else if(value > HighAlarm)
                    {
                        msg += "过高";
                        state= MonitorValueState.High;
                    }
                    ValueStateChanged(state, msg+" 当前值："+value.ToString(),ValueId);
                }
            }   
        }
        public string ValueDesc { get; set; }
    }
}
