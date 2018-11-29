using Strans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            db.Credentials.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }
    }
}