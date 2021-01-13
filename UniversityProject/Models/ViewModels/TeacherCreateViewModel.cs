using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityProject.Models.ViewModels
{
    public class TeacherCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> FieldIdList { get; set; }
    }
}