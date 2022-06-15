using DullStore.DAO;
using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DullStore.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        private void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success";
                    break;

                case "warning":
                    TempData["AlertType"] = "alert-warning";
                    break;

                case "error":
                    TempData["AlertType"] = "alert-error";
                    break;

                default:
                    TempData["AlertType"] = "";
                    break;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAction(Account acc)
        {
            UserDAO user = new UserDAO();
            bool check = user.Login(acc.taikhoan, acc.matkhau);
            if (check)
            {
                Session["UserName"] = acc.taikhoan;
                return RedirectToAction("AdminIndex", "AdminHome");
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}