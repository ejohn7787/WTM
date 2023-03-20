using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    public class KYJSystemController : Controller
    {
        KYJSystemManager kyjSystemManager = new KYJSystemManager();

        // GET: KYJSystem
        public ActionResult Index()
        {
            kyjSystemManager.InitialTimer();
            return View("KYJIndex");
        }
        /// <summary>
        /// 获取空压机数据的JSON数据
        /// </summary>
        /// <returns>返回JSON数据</returns>
        [HttpGet]
        public ActionResult GetKYJSysData()
        {
            List<KYJSystem> kyjSystems = kyjSystemManager.KYJSystems();
            return Json(kyjSystems,JsonRequestBehavior.AllowGet);
        }
    }
}