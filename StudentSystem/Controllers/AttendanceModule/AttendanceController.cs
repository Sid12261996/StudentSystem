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
        public ActionResult Attendance(string id,CollectionOfClasses classes,User user,Attendance attendance)
        {
            
            
            var query = Query.EQ("_id", new ObjectId(id));
            var realStudent = MongoInst.MCollection.Find(query).SetFields(Fields.Include("SchoolName"));
             string t = "";
            foreach (var i in realStudent) { t = i.SchoolName; }

            string p="";
            var schoolId = MongoInst.SchoolCollection.Find(Query.EQ("SchoolName", t)).SetFields(Fields.Include("_id"));
            foreach (var i in schoolId) { p = i._id.ToString(); }
            
            var q = Query.EQ("SchoolId", new ObjectId(p));
            var stu = MongoInst.classCollection.FindAs<CollectionOfClasses>(q).SetFields(Fields.Exclude("StudentId,SchoolId"));
            var dummy = stu.ToList();
            
           
            var T = new Tuple<IEnumerable<CollectionOfClasses>, Attendance>(dummy, attendance);
            return View(T);
        }

      
    }
}
