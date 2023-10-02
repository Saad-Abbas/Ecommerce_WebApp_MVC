using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garments.Models;
using System.IO;

namespace Garments.Controllers
{
    public class ProductController : Controller
    {

        Addnewproduct ad = new Addnewproduct();
        public string value = "";

        
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult AddNewProduct()
        {
            ViewBag.Mylist = new List<Addnewproduct>(ad.productlist());
            
            return View();
        }
        public ActionResult SaveData(Addnewproduct item)
        {
            if (item.ProductName != null && item.Price != null && item.ImageUpload != null && item.producttype != null || item.shortdiscription != null  )
            {

                string fileName = Path.GetFileNameWithoutExtension(item.ImageUpload.FileName);
                string extention = Path.GetExtension(item.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extention;
                item.PicUrl = fileName;
                item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"),fileName));
                ad.ADD(item);
                value = "successfully added";
            }
            else
            {
                value = "Product Not Inserted /n Insert Again ";
            }
            
            return Json(value,JsonRequestBehavior.AllowGet);
        }
        //Quick View 
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



        //update portion get data from P_ID and
        [HttpGet]
        public ActionResult Update(int P_ID)
        {
            Addnewproduct ad = new Addnewproduct();
            ad.Product_ID = P_ID;
            Addnewproduct search_pdct = ad.Search();
            return View(search_pdct); 
         // return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Addnewproduct pdct)
        {
            pdct.Update();
            return RedirectToAction("AddNewProduct");
            // return Json(value, JsonRequestBehavior.AllowGet);
        }


        // deleting Products
        [HttpGet]
        public ActionResult Delete(int P_ID)
        {
            Addnewproduct ad = new Addnewproduct();
            ad.Product_ID = P_ID;
            ad.Delete();

            return RedirectToAction("AddNewProduct");     // after deleteing goto main product Adding Page
            // return Json(value, JsonRequestBehavior.AllowGet);
        }





       



    }
}