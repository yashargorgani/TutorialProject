using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityProject.DAL;
using UniversityProject.Models;
using UniversityProject.Models.ViewModels;

namespace UniversityProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        UniversityDbContext db;

        public StudentController()
        {
            db = new UniversityDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Student> model = db.Student.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            LoadFieldSelecttList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Inputs are NOT Correct";
                LoadFieldSelecttList();
                return View(entity);
            }

            //Add to database
            db.Student.Add(entity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            LoadFieldSelecttList();

            Student entity = db.Student.Find(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(Student entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Inputs are NOT Correct";
                LoadFieldSelecttList();
                return View(entity);
            }

            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string StudentCode)
        {
            Student entity = db.Student.Where(x => x.StudentCode == StudentCode).FirstOrDefault();

            if (entity != null)
                db.Student.Remove(entity);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult P_Details(int id)
        {
            Student model = db.Student.Find(id);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult P_Create(Student entity)
        {
            db.Student.Add(entity);

            db.SaveChanges();

            return Json(new { message ="Student saved successfuly." });
        }

        private void LoadFieldSelecttList()
        {
            List<Field> fields = db.Field.ToList();

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in fields)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = item.Caption,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.FieldSelectList = listItems;
        }

        public ActionResult Test()
        {
            Student model = new Student()
            {
                FirstName = "Yashar",
                LastName = "Gorgani",
                StudentCode = "8615789"
            };

            return View(model);
        }
    }
}