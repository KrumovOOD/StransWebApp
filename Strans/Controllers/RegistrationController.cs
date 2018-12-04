using Strans.Common;
using Strans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Strans.Controllers
{
    public class RegistrationController : Controller
    {

        STransEntities db = new STransEntities();


        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveData(Credential model)
        {
            model.IsValid = false;
            db.Credentials.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Confirm(int regId)
        {
            ViewBag.regId = regId;
            return View();
        }

        public JsonResult RegisterConfirm(int regId)
        {
            Credential Data = db.Credentials.Where(x => x.Id == regId).FirstOrDefault();
            Data.IsValid = true;
            db.SaveChanges();
            var msg = "Your Email is Verified";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
        public ActionResult CheckValidUser(string username, string password)
        {
            string result = "Fail";
                         
            var dataItem = db.Credentials.Where(x => x.Username == username/* && x.Password == password*/).Select(x => new CredentialModel
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                Username = x.Username,
                IsValid = x.IsValid               
            }).FirstOrDefault();
                      
            
            if (dataItem != null)
            {
                Session["UserID"] = dataItem.Id.ToString();
                Session["UserName"] = dataItem.Username.ToString();
                result = "Success";
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AfterLogin()
        {
            if (Session["UserID"] != null)
            {
                return View("AfterLogin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
       
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }



    }
}