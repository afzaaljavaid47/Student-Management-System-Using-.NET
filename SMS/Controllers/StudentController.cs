using Microsoft.Ajax.Utilities;
using SMS.DB;
using SMS.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.DB;
using Newtonsoft.Json;
using Microsoft.Security.Application;
using Vereyon.Web;
using System.Dynamic;

namespace SMS.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        Operations StudentDBContext =null;
        public StudentController() {
            StudentDBContext = new Operations();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentModel studentModel,string create)
        {
            var sanitizer = HtmlSanitizer.SimpleHtml5Sanitizer();
            if (ModelState.IsValid)
            {
                studentModel.address = sanitizer.Sanitize(studentModel.address);
                int id = StudentDBContext.AddData(studentModel);
                ViewBag.Id = id;
                return View();
            }
            return View();
        }
        //[OutputCache(Duration = 20,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult List()
        {
            var studentData=StudentDBContext.getAllData();
            //var usersData=StudentDBContext.getAllUsers();
            //dynamic model = new ExpandoObject();
            //model.studentModel= studentData;
            //model.userModel = usersData;
            return View(studentData);
        }
        public ActionResult Details(int id)
        {
            var studentData = StudentDBContext.getStudentData(id);
            return View(studentData);
        }
        public ActionResult Delete(int id)
        {
            bool output = StudentDBContext.deleteStudentData(id);
            if(output)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            var studentData = StudentDBContext.getStudentData(id);
            return View(studentData);
        }
        [HttpPost]
        public ActionResult Edit(StudentModel model)
        {
            bool studentData = StudentDBContext.updateStudentData(model,model.id);
            return RedirectToAction("List");
        }

        public JsonResult getStudents()
        {
            var studentData = StudentDBContext.getAllData();
            //var jsonData=JsonConvert.SerializeObject(studentData);
            return Json(studentData, JsonRequestBehavior.AllowGet);
        }
    }
}