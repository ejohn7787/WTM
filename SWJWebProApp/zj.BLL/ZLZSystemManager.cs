using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public class ZLZSystemManager
    {
        private ZLZSystemService zlzSystemService = new ZLZSystemService();
        public void InitialTimer()
        {
            zlzSystemService.InitialTimer();
        }
        public List<ZLZSystem> ZLZSystems()
        {
            return zlzSystemService.ZLZSystems();
        }
    }
}
