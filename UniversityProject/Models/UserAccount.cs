using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }


        public virtual Role Role { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}