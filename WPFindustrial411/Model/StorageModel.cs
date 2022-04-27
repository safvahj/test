using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFindustrial411.Model
{
    public class StorageModel
    {
        //从站id
        public string id { get; set; }
        //从站地址
        public int SlaveAddress { get; set; }
        //功能码
        public string FunCode { get; set; }
        //起始地址
        public int StartAddress { get; set; }
        //长度
        public int Length { get; set; } 

    }
}
