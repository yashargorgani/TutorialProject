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
    [Authorize(Roles ="Admin")]
    public class TeacherController : Controller
    {
        UniversityDbContext db;

        public TeacherController()
        {
            db = new UniversityDbContext();
        }

        // GET: Teacher
        public ActionResult Index()
        {
            var model = db.Teachers.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            LoadFieldSelecttList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherCreateViewModel entity)
        {
            var teacher = new Teacher()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            foreach (var id in entity.FieldIdList)
            {
                var field = db.Field.Find(id);

                teacher.Fields.Add(field);
            }

            db.Teachers.Add(teacher);

            db.SaveChanges();

            return RedirectToAction("Index");
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
    }
}