﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFindustrial411.Model
{
    public class DeviceModel
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }

        public bool IsRunning { get; set; }

        public bool IsWarning { get; set; } = false;
        public ObservableCollection<MonitorValueModel> MonitorValueList { get; set; }=new 
            ObservableCollection<MonitorValueModel>();

        public ObservableCollection<WarningMessageModel> WarningMessageList { get; set; }=new
            ObservableCollection<WarningMessageModel>();
    }
}
