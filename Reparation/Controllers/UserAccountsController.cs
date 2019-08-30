using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reparation.DAL;
using Reparation.Models;

namespace Reparation.Controllers
{
    public class UserAccountsController : Controller
    {
        private OurDbContext db = new OurDbContext();

        // GET: UserAccounts
           public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccounts.ToList());
            }

        }

        public ActionResult Register()
        {
            if (Session["UserId"] == null && Session["Role"].ToString()!= "Admin")
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Register(UserAccounts account)
        {

            using (OurDbContext db = new OurDbContext())
            {

                var UserStatus = db.userAccounts.FirstOrDefault(u => u.Anummer == account.Anummer);

                if (UserStatus != null)

                {

                    ViewBag.message = account.Anummer + " " + "already exists, Contact Administrator. ";
                }
                else if (ModelState.IsValid)
                {
                    //using (OurDbContext db = new OurDbContext())
                    {
                        db.userAccounts.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.FullName + " " + "has been successfully registered";

                }

                return View();
            }

        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccounts user)
        {
            using (OurDbContext db = new OurDbContext())
            {

                var UserLoggingIn = db.userAccounts.FirstOrDefault(u => u.Anummer == user.Anummer && u.Password == user.Password);
                if (UserLoggingIn != null)
                {
                    Session["UserId"] = UserLoggingIn.UserId.ToString();
                    Session["FullName"] = UserLoggingIn.FullName.ToString();
                    Session["Anummer"] = UserLoggingIn.Anummer.ToString();
                    Session["ButikId"] = UserLoggingIn.ButikId.ToString();
                    var Role = UserLoggingIn.Role.ToString();
                    Session["Role"] = Role.ToString();

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "AnstallaningNummer or Password incorrect");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "WorkOrders");
            }
            else
            {
                return RedirectToAction("Login");

            }
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }

}
