using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public class JYZSystemManager
    {
        private JYZSystemService jyzSystemService = new JYZSystemService();
        public void InitialTimer()
        {
            jyzSystemService.InitialTimer();
        }
        public List<JYZSystem> JYZSystems()
        {
            return jyzSystemService.JYZSystems();
        }
    }
}
