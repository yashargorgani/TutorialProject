using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityProject.DAL;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        UniversityDbContext db;

        public CourseController()
        {
            db = new UniversityDbContext();
        }

        public ActionResult Index()
        {
            var model = db.Courses.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            LoadMultiSelects();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course entity)
        {
            entity.Id = Guid.NewGuid();

            db.Courses.Add(entity);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult P_LoadTeachers(int fieldId)
        {
            var teachers =
                db.Teachers.Where(x => x.Fields.Select(y => y.Id).Contains(fieldId)).ToList();

            var selecList = new List<SelectListItem>();

            foreach (var item in teachers)
            {
                selecList.Add(new SelectListItem()
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.Id.ToString()
                });
            }

            return Json(selecList, JsonRequestBehavior.AllowGet);
        }

        void LoadMultiSelects()
        {
            List<Field> fields = db.Field.ToList();
            List<SelectListItem> fieldListItems = new List<SelectListItem>();

            foreach (var item in fields)
            {
                fieldListItems.Add(new SelectListItem()
                {
                    Text = item.Caption,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.FieldSelectList = fieldListItems;

            var coursebases = db.CourseBases.ToList();
            var coursebaseListItems = new List<SelectListItem>();

            foreach (var item in coursebases)
            {
                coursebaseListItems.Add(new SelectListItem()
                {
                    Text = item.Caption,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.CourseBaseSelectList = coursebaseListItems;
        }
    }
}