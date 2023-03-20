using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    
    public class JYZSystemController : Controller
    {
        private JYZSystemManager jyzSystemManager = new JYZSystemManager();
        
        // GET: JYZSystem
        public ActionResult Index()
        {
            jyzSystemManager.InitialTimer();  //数据定时刷新
            
            return View("JYZIndex");
        }
        /// <summary>
        /// 返回JSON数据
        /// </summary>
        /// <returns>动作方法的返回类型，可以返回各种类型</returns>
        [HttpGet]
        public ActionResult GetJYZSysData()
        {
            List<JYZSystem> jyzSystems = jyzSystemManager.JYZSystems();
            return Json(jyzSystems,JsonRequestBehavior.AllowGet);  //返回JSON格式的数据，给前端使用
        }

    }
}