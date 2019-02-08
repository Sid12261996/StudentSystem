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
        public Student Astudent = new Student();
        public IEnumerable<Student> s;
        public IMongoCollection<Student> mongo;
    
       
       
        // GET: Register
        public ActionResult Register()
        {
            
            return View();
        }

        // GET: Register/Details/5
        public ActionResult Details( string name)
        {
            var query = Query.EQ("stuName", name);
            var stu = MongoInst.MCollection.FindAs<Student>(query);
            var dummy = stu.ToList();
            return View(dummy);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View("Register");
        }
        public ActionResult Index()
        {
           
            var stu = MongoInst.MCollection.FindAll();
            var dummy = stu.ToList();



            return View(dummy);
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(Student Stud)
        {
            if (ModelState.IsValid) {
                MongoInst.MCollection.Insert(Stud);
            }
              return RedirectToAction("Index");
            
           
        }

        // GET: Register/Edit/5
        public ActionResult Edit(string name)
       {
            var query = Query.EQ("stuName", name);
            var stu = MongoInst.MCollection.FindOne(query);
            
            return View(stu);
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Student stud)
        {

            if (ModelState.IsValid) {
                var updateQuery = Update.Set("email", stud.email)
                                            .Set("mobNo", stud.mobNo)
                                            .Set("Address", stud.Address);





                var query = Query.EQ("_id", new ObjectId(id));


                MongoInst.MCollection.Update(query, updateQuery);
                }

                return RedirectToAction("Index");
           
        }



        // GET: Register/Delete/5
        public ActionResult Delete(string name)
        {
            var query = Query.EQ("stuName", name);
            var stu = MongoInst.MCollection.FindOne(query);

            return View(stu);
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(string name, Student stud)
        {
            try
            {
                var query = Query.EQ("stuName", name);
                var stu = MongoInst.MCollection.FindOne(query);
                MongoInst.MCollection.Remove(query);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
