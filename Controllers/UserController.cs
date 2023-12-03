using Microsoft.AspNetCore.Mvc;
using Pass_It_Out.Models;
using Pass_It_Out.Services;
using Pass_It_Out.Services.UserServices;
using Pass_It_Out.View_Models;
using System.Reflection.Metadata.Ecma335;

namespace Pass_It_Out.Controllers
{
    public class UserController : Controller
    {
        private IUser service;
        public UserController(IUser service) 
        { 
            this.service = service;
        }

        [HttpGet]
        public IActionResult UserRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserId = userVM.UserId;
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;
                user.Location= userVM.Location;
                user.Password = userVM.Password;
                bool success = service.Registration(user);
                if (success)
                {
                    TempData["Message"] = "Data Saved Successfully!!!";
                    return View("UserLogin");
                }
                else
                {
                    TempData["Message"] = "Data not Saved!!!";
                }
                return View();
            }
            else
            {
                return View("UserRegistration");
            }
        }

        [HttpPost]
        public IActionResult UserLogin(UserVM user)
        {
            User user1 = new User();
            user1.UserId = user.UserId;
            user1.Password = user.Password;
            User LoginUser=service.GetUserById(user1.UserId);
            if(LoginUser!=null)
            {
                TempData["Message"] = "LogIn Successfull!!!";
                HttpContext.Session.SetString("UserId", LoginUser.UserId);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                TempData["Message"] = "LogIn UnSuccessfull!!! Please Register";
            }
            return View("UserLogin");
        }

        public ActionResult UserLogout()
        {
            if(HttpContext.Session.GetString("UserId")!=null)
            {
                HttpContext.Session.Remove("UserId");
            }
            return RedirectToAction("UserLogin", "User");
        }
    }
}
