﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFindustrial411.BLL
{
    public class DataResult<T>
    {
        public bool State { get; set; }=false;
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class DataResult : DataResult<string> { }
}
