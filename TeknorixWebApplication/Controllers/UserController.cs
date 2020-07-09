using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknorixWebApplication.Implementation;
using TeknorixWebApplication.Models;

namespace TeknorixWebApplication.Controllers
{
    public class UserController : Controller
    {
        public readonly UserService _iuserService = null;

        public UserController()
        {
            _iuserService = new UserService();
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult UserDetail()
        {
            return View("UserDetail");
        }

        public ActionResult Index()
        {
            List<UserModel> list = new List<UserModel>();
            list = _iuserService.GetList();
            return View("Index", list);
        }

        public ActionResult AddEditUser(UserModel model)
        {
            if(model.UserId > 0)
            {
                model = _iuserService.UserDetailById((int)model.UserId);
            }
            return View("UserDetail", model);
        }

        public ActionResult SaveUser(UserModel model)
        {
            int UserId = _iuserService.SaveUser(model);
            return RedirectToAction("AddEditUser", "User", new { UserId = UserId});
        } 
    }
}