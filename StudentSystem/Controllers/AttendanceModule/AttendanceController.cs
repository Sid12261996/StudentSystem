using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentSystem.Controllers.AttendanceModule
{
    using MongoDB.Driver.Builders;
    using StudentSystem.Models;
 

    public class AttendanceController : Controller
    {
        public mongoConnection MongoInst = new mongoConnection();
        // GET: Attendance
        public ActionResult Attendance(CollectionOfClasses classes)
        {
            var cl = MongoInst.classCollection.FindAll();
           
            return View(cl.ToList());
        }

      
    }
}
