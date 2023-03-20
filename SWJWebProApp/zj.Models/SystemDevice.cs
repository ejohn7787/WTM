using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zj.Models
{
    /// <summary>
    /// 系统设备类
    /// </summary>
    public class SystemDevice
    {
        public int SystemId { get; set; }  //ID
        public string SystemName { get; set; }    //系统名称
        public string CodeName { get; set; }      //系统代号
    }
}
