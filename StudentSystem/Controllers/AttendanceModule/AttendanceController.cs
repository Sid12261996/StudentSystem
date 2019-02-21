using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;


namespace StudentSystem.Controllers.AttendanceModule
{
    using MongoDB.Driver.Builders;
    using StudentSystem.Models;
 

    public class AttendanceController : Controller
    {
        public mongoConnection MongoInst = new mongoConnection();
        // GET: Attendance
        public ActionResult Attendance(CollectionOfClasses classes,Attendance attendance, string id)
        {
            var query = Query.EQ("email", id);
            
            var stu = MongoInst.MCollection.FindAs<Student>(query);

            var T = new Tuple<CollectionOfClasses, Attendance>(classes,attendance);
            return View(T);
        }

      
    }
}
