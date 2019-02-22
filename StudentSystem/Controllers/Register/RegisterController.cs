using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using StudentSystem.Models;

namespace StudentSystem.Controllers.Register
{
    [Authorize]
    public class RegisterController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public mongoConnection MongoInst = new mongoConnection();
       
       
       
        // GET: Register
        public ActionResult Register(Student stud, CollectionOfClasses classes)
        {
            
            
            return View();
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
            var stu = MongoInst.MCollection.Find(query );

            var dummy = stu.ToList<Student>();


            
            return View(dummy);
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        // POST: Register/Register
        [HttpPost]
        public  ActionResult Register(Student Stud,School school,User user, CollectionOfClasses classes)
       {
            
            if (ModelState.IsValid) {

                var searchForDuplicateClass = Query.EQ("ClassName", Stud.classname);
                var searchForDuplicateSchool = Query.EQ("SchoolName", Stud.SchoolName);
                var searchForDuplicateUser = Query.EQ("email", Stud.email);
                Stud.changeTime = DateTime.Now.ToString();
                user.email = Stud.email;
                user.pwd = Stud.pwd;
                MongoInst.MCollection.Insert(Stud);
              


                var resultClass = MongoInst.classCollection.Find(searchForDuplicateClass).SetFields(Fields.Exclude("UserId,StudentId"));
                var resultSchool = MongoInst.SchoolCollection.Find(searchForDuplicateSchool);
                var resultUser = MongoInst.Users.Find(searchForDuplicateUser).SetFields(Fields.Exclude("pwd,_id"));



                if (resultSchool.ToList().Count == 0)
                {
                    school.SchoolName = Stud.SchoolName;
                    MongoInst.SchoolCollection.Insert(school);
                   
                }
                if (resultClass.ToList().Count == 0)
                {
                    classes.ClassName = Stud.classname;
                    classes.StudentId = Stud._id;
                    classes.SchoolId = school._id;
                    MongoInst.classCollection.Insert(classes);

                }
                if (resultUser.ToList().Count == 0)
                {
                    user._id = school._id;
                    MongoInst.Users.Insert(user);
                }

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
