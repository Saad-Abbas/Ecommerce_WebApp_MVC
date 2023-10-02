using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garments.Models;

namespace Garments.Controllers
{
    public class AddToCartController : Controller
    {
        List<Orders> od = new List<Orders>();
        // GET: AddToCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listdata(Orders item)
        {
            od.Add(item);        
            return View(od);
        }

        public ActionResult OrderListdata()
        {            
            return View(od);
        }



    }
}