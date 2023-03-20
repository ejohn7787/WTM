using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;
namespace SWJWebProApp.Controllers
{
    public class ZLZSystemController : Controller
    {
        ZLZSystemManager zlzSystemManager = new ZLZSystemManager();
        // GET: ZLZSystem
        public ActionResult Index()
        {
            zlzSystemManager.InitialTimer();
            return View("ZLZIndex");
        }
        [HttpGet]
        public ActionResult GetZLZSysData()
        {
            List<ZLZSystem> zlzSystems = zlzSystemManager.ZLZSystems();
            return Json(zlzSystems,JsonRequestBehavior.AllowGet);
        }
    }
}