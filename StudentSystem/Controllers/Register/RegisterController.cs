using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using StudentSystem.Models;

namespace StudentSystem.Controllers.Register
{

    public class RegisterController : Controller
    {
        
        public mongoConnection MongoInst = new mongoConnection();
       
       
       
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        public PartialViewResult SchoolName(School school)
        {
            return PartialView(school);
        }
      



        // GET: Register/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
        var query =  Query.EQ("_id", new ObjectId(id)) ;
            
            

            var stu = MongoInst.MCollection.FindAs<Student>(query);
            
           
            return View(stu.ToList());
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View("Register");
        }
        [Authorize]
        public ActionResult Index()
        {
            var query = Query.NE("changeTime", "null");
            var stu = MongoInst.MCollection.Find(query);

            var dummy = stu.ToList<Student>();


            
            return View(dummy);
        }

        // POST: Register/Register
        [HttpPost]
        public ActionResult Register(Student Stud,School school)
       {
            if (ModelState.IsValid) {
                Stud.changeTime = DateTime.Now.ToString();
                MongoInst.MCollection.Insert(Stud);
                school.SchoolName = Stud.SchoolName;
                MongoInst.SchoolCollection.Insert(school);



                return RedirectToAction("Index");
            }

            return View();
                
           
        }

        // GET: Register/Edit/5
        public ActionResult Edit(string name)
       {
            IMongoQuery query = Query.EQ("stuName", name);
            Student stu = MongoInst.MCollection.FindOne(query);
            
            return View(stu);
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Student stud)
        {

                var updateQuery = Update.Set("email", stud.email)
                                            .Set("mobNo", stud.mobNo)
                                            .Set("Address", stud.Address);





                var query = Query.EQ("_id", new ObjectId(id));
            stud.changeTime = DateTime.Now.ToString();

                MongoInst.MCollection.Update(query, updateQuery);
                

                return RedirectToAction("Index");
           
        }



        // GET: Register/Delete/5
        public ActionResult Delete(string name)
        {
            IMongoQuery query = Query.EQ("stuName", name);
            var stu = MongoInst.MCollection.FindOne(query);

            

            return View(stu);
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Student stud)
        {
            try
            {
                var query = Query.EQ("_id",new ObjectId(id));
                //var stu = MongoInst.MCollection.FindOneById(new ObjectId(id));
                // MongoInst.MCollection.Remove(query);
               // var query = Query.EQ("stuName", name);
                var updateQuery = Update.Set("changeTime", "null");



                var stu = MongoInst.MCollection.Update(query, updateQuery);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("error");
            }
        }

        public Student updateDate(Student stud) {
            stud.changeTime = DateTime.Now.ToString();
            return stud;
        }
    }
}
