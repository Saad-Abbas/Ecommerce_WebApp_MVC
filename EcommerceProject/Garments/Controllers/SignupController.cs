using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garments.Models;

namespace Garments.Controllers
{
   
    public class SignupController : Controller
    {
        public static bool chk = false;
           signup_cls sign = new signup_cls();
        public string value = "";
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSignup()
        {
            if (chk == true)
            {
                return RedirectToAction("AddNewProduct", "Product");
            }
            else if ((chk == true))
            {
                return RedirectToAction("ViewAllProducts", "CustomerView");
            }
            else
            {
                return RedirectToAction("ViewAllProducts", "CustomerView");
            }

        }
        //create signup account
        [HttpPost]
        public ActionResult signup(signup_cls signup)
        {
            if (signup.Password == signup.RetypePassword)
            {
                signup.Usertype = "vender";
                sign.ADD(signup);                    
                value = "Successfully Account Created";
            }
            else if (signup.Password != signup.RetypePassword)
            {
                value = "Both Passwords are Different /n Enter Again";
            }
            var result = value;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult checkuser(signup_cls formdata)
        {
            List<signup_cls> lst = sign.Getuserandpass();
            foreach (var item in lst)
            {
                item.Username.Trim();
                item.Password.Trim();
                if (item.Username.Trim() == formdata.Username && item.Password.Trim() == formdata.Password)
                {
                    value = "Login Successfull";
                    chk = true;
                   // return RedirectToAction("AddNewProduct", "Product");
                    break;
                }
                else if (item.Username.Trim() == formdata.Username && item.Password.Trim() != formdata.Password)
                {
                    value = "Incorrect Password";
                 //   return RedirectToAction("ViewAllProducts", "CustomerView");
                }
                else if (item.Username.Trim() != formdata.Username && item.Password.Trim() == formdata.Password)
                {
                    value = "Incorrect Username";
                    //   return RedirectToAction("ViewAllProducts", "CustomerView");
                }
                else
                {
                    value = "Incorrect Username & Password ";
                }
            }
            var result = value;
            return Json(result, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult Signing()
        {

            return View();
        }

    }
}