using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.Models;

namespace zj.DAL
{
    /// <summary>
    /// 模拟数据库
    /// </summary>
    public  class SystemDeviceService
    {
        List<SystemDevice> systemdevices = new List<SystemDevice>
        {
            new SystemDevice{SystemId=1001,SystemName="加压站",CodeName="JYZ" },
             new SystemDevice{SystemId=1002,SystemName="空压机",CodeName="KYJ" },
              new SystemDevice{SystemId=1003,SystemName="锅炉房",CodeName="GLF" },
               new SystemDevice{SystemId=1004,SystemName="制冷站",CodeName="ZLZ" },
               new SystemDevice{SystemId=1005,SystemName="温湿度采集系统",CodeName="THM" },
               new SystemDevice{SystemId=1006,SystemName="电机监控系统",CodeName="MMS" },
               new SystemDevice{SystemId=1007,SystemName="运动控制平台",CodeName="MCP" },
               new SystemDevice{SystemId=1007,SystemName="机器视觉平台",CodeName="VCP" },

        };
        public List<SystemDevice> QuerySystemDevice()
        {
            return systemdevices;
        }

    }
   
}
