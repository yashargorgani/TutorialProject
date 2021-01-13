using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UniversityProject.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name ="Base Course")]
        public int CourseBaseId { get; set; }

        [Required]
        [Display(Name = "Field")]
        public int FieldId { get; set; }

        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Required]
        [Display(Name = "Units")]
        public int UnitCount { get; set; }

        public virtual CourseBase CourseBase { get; set; }
        public virtual Field Field { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}