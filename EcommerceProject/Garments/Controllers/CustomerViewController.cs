using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garments.Models;

namespace Garments.Controllers
{
    public class CustomerViewController : Controller
    {
        Addnewproduct ad = new Addnewproduct();
        public string value = "";
        // GET: CustomerView
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult ViewAllProducts()
        {
            ViewBag.Mylist = new List<Addnewproduct>(ad.productlist());

            return View();
        }

        //Quickview of P_ID 
        [HttpGet]
        public ActionResult SingleView(int P_ID)
        {
            Addnewproduct ad = new Addnewproduct();
            ad.Product_ID = P_ID;
           // Addnewproduct search_pdct = ad.Search();
            ViewBag.singleproduct = ad.Search();
            return View();
            //return View(search_pdct);
            // return Json(value, JsonRequestBehavior.AllowGet);
        }

        // search with product type
        public ActionResult ViewTypeProducts(string producttype)
        {
            ViewBag.Mylist = new List<Addnewproduct>(ad.Searchproducttype(producttype));

            return View();
        }

        public ActionResult Buypackages()
        {
            return RedirectToAction("Packages", "BuyPackages");

           
        }


    }
}