using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Fields = new HashSet<Field>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}