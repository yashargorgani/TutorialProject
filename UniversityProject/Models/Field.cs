using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class Field
    {
        public Field()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Caption { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}