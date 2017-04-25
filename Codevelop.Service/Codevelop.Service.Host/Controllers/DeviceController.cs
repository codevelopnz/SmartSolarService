using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codevelop.Service.Host.Controllers
{
    /// <summary>
    /// Configuration and summary related methods for a single device
    /// </summary>
    public class DeviceController : Controller
    {
        // GET: Device
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Summary()
        {
            return View();
        }
    }
}