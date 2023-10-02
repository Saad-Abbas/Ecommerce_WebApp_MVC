using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garments.Controllers
{
    public class BuyPackagesController : Controller
    {
        // GET: BuyPackages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Packages()
        {
            return View();

        }
    }
}