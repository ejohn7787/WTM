using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zj.BLL;
using zj.Models;

namespace SWJWebProApp.Controllers
{
    public class HomeController : Controller
    {
        private  SystemDeviceManager systemDeviceManager = new SystemDeviceManager();
        // GET: Home
        public ActionResult Index()
        {
            //加载时
            ViewBag.SystemDevice = systemDeviceManager.QuerySystemDevice();  //把查找的数据放入ViewBag
            return View();
        }
    }
}