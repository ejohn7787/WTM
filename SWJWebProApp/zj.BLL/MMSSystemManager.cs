using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public  class MMSSystemManager
    {
        private MMSSystemService mmsSystemService = new MMSSystemService();
        public void InitialTimer()
        {
            mmsSystemService.InitialTimer();
        }
        public List<MMSSystem> MMSSystems()
        {
            return mmsSystemService.MMSSystems();
        }
    }
}
