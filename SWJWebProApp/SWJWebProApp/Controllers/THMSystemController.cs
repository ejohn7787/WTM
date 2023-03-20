using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    public class THMSystemController : Controller
    {
        private THMSystemManager thmSystemManager = new THMSystemManager();

        // GET: THMSystem
        public ActionResult Index()
        {
            thmSystemManager.InitialTimer();
            return View("THMIndex");
        }
        [HttpGet]
        public ActionResult GetTHMSysData()
        {
            List<THMSystem> thmSystems = thmSystemManager.THMSystems();
            return Json(thmSystems,JsonRequestBehavior.AllowGet);
        }
    }
}