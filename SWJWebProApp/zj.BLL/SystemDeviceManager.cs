using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;
namespace zj.BLL
{
    public class SystemDeviceManager
    {
        private SystemDeviceService systemDeviceService = new SystemDeviceService();
        public List<SystemDevice> QuerySystemDevice()
        {
            return systemDeviceService.QuerySystemDevice();
        }
    }
}
