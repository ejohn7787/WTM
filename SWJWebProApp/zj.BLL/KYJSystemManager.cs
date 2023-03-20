using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public class KYJSystemManager
    {
        private KYJSystemService kyjSystemService = new KYJSystemService();
        public void InitialTimer()
        {
            kyjSystemService.InitialTimer();
        }
        public List<KYJSystem> KYJSystems()
        {
            return kyjSystemService.KYJSystems();
        }
    }
}
