using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    public class MMSSystemController : Controller
    {
        private MMSSystemManager mmsSystemManager = new MMSSystemManager();
        // GET: MMSSystem
        public ActionResult Index()
        {
            mmsSystemManager.InitialTimer();
            return View("MMSIndex");
        }
        [HttpGet]
        public ActionResult GetMMSSysData()
        {
            List<MMSSystem> mmsSystems = mmsSystemManager.MMSSystems();
            return Json(mmsSystems,JsonRequestBehavior.AllowGet);
        }
    }
}