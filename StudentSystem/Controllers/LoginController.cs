using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Login( LoginUser user, string ReturnUrl)
        {
            try
            {
                IMongoQuery queryEmail = Query.EQ("email",user.Email);
             
                var UserData = mongo.MCollection.FindOne(queryEmail);
                UserData.ToString();

                if (UserData.email == user.Email && UserData.pwd == user.Password) {

                    FormsAuthentication.SetAuthCookie(user.Email,false);

                    return RedirectToAction(ReturnUrl);

                }

                return View(user);
            }
            catch
            {
                return View();
            }
        }

        
    }
}
