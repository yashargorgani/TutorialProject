using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityProject.DAL;
using UniversityProject.Models;
using UniversityProject.Models.ViewModels;

namespace UniversityProject.Controllers
{
    public class AccountController : Controller
    {
        UniversityDbContext db;

        public AccountController()
        {
            db = new UniversityDbContext();
        }

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel entity, string ReturnUrl)
        {
            var user = db.UserAccount.FirstOrDefault(x => x.EmailAdress == entity.EmailAdress && x.Password == entity.Password);

            if(user == null)
            {
                ViewBag.Message = "Email Address OR Password is NOT correct";
                return View(entity);
            }

            FormsAuthentication.SetAuthCookie(entity.EmailAdress, entity.Remember);


            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles="Admin")]
        public ActionResult Register()
        {
            LoadSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel entity)
        {
            if(db.UserAccount.Any(x => x.EmailAdress == entity.EmailAdress))
            {
                ViewBag.Message = "Email Address already registered";
                LoadSelectList();
                return View(entity);
            }

            var user = new UserAccount()
            {
                EmailAdress = entity.EmailAdress,
                Password = entity.Password,
                RoleId = entity.RoleId,
                TeacherId = entity.TeacherId,
                StudentId = entity.StudentId
            };

            db.UserAccount.Add(user);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult P_LoadSearchResult(int RoleId, string SearchName)
        {
            var role = db.Role.Find(RoleId);

            var selectList = new List<SelectListItem>();

            if(role.Caption == "Teacher")
            {
                var list = db.Teachers.Where(x => (x.FirstName + " " + x.LastName).Contains(SearchName)).ToList();

                foreach(var item in list)
                {
                    selectList.Add(new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName,
                        Value = item.Id.ToString()
                    });
                }

                ViewBag.Teacher = selectList;

                return PartialView("P_Teacher");
            }
            else if(role.Caption == "Student")
            {
                var list = db.Student.Where(x => (x.FirstName + " " + x.LastName).Contains(SearchName)).ToList();

                foreach (var item in list)
                {
                    selectList.Add(new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName,
                        Value = item.Id.ToString()
                    });
                }

                ViewBag.Students = selectList;

                return PartialView("P_Student");
            }

            return Content("");
        }

        void LoadSelectList()
        {
            var roles = db.Role.ToList();
            var selectList = new List<SelectListItem>();

            foreach (var item in roles)
            {
                selectList.Add(new SelectListItem()
                {
                    Text = item.Caption,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Roles = selectList;
        }
    }
}