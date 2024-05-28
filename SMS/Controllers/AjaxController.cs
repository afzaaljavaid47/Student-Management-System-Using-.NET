using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SMS.DB;
using SMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class AjaxController : Controller
    {
        Operations studentDBContext = null;
        public AjaxController()
        {
            studentDBContext = new Operations();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                int id = studentDBContext.AddData(model);
                ViewBag.Id = id;
                return Json("Data Saved Successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("Validation Failed",JsonRequestBehavior.AllowGet);
        }
        public JsonResult getStudents()
        {
            var studentData=studentDBContext.getAllData();
            var jsonData = JsonConvert.SerializeObject(studentData);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}