using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using StudentSystem.Models;




namespace StudentSystem.Controllers.Login
{


    public class LoginController : Controller
    {
        public mongoConnection mongo = new mongoConnection();

        // GET: Login/Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: Login/Login
        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {
            try
            {
                IMongoQuery queryEmail = Query.EQ("email", user.Email);

                var UserData = mongo.Users.FindOne(queryEmail);
                UserData.ToString();



                if (UserData.Email == user.Email && UserData.pwd == user.pwd) {

                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    string dummy = ReturnUrl;
                    return RedirectToAction("Index", "Register");

                }
                ViewBag.ErrorMessage = "Email or Password is Incorrect";
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult UserRegister() {
            return View();
        }

    }
}
