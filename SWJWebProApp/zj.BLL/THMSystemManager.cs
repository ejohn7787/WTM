using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public class THMSystemManager
    {
        private THMSystemService thmSystemService = new THMSystemService();
        public void InitialTimer()
        {
            thmSystemService.InitialTimer();
        }
        public List<THMSystem> THMSystems()
        {
            return thmSystemService.THMSystems();
        }
    }
}
