using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    
    public class GLFSystemController : Controller
    {
        private GLFSystemManager glfSystemManager = new GLFSystemManager();
        // GET: GLFSystem
        public ActionResult Index()
        {
            glfSystemManager.InitialTimer();  //数据定时刷新
            return View("GLFIndex");
        }
        /// <summary>
        /// 返回JSON字符串数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGLFSysData()
        {
            List<GLFSystem> glfSystems = glfSystemManager.GLFSystems();
            return Json(glfSystems,JsonRequestBehavior.AllowGet);
        }
    }
}