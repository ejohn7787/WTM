using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zj.DAL;
using zj.Models;

namespace zj.BLL
{
    public  class GLFSystemManager
    {
        private GLFSystemService glfSystemService = new GLFSystemService();
        public void InitialTimer()
        {
            glfSystemService.InitialTimer();
        }
        public List<GLFSystem> GLFSystems()
        {
            return glfSystemService.GLFSystems();
        }
    }
}
