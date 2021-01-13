using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student Code is Required")]
        [StringLength(maximumLength:7, MinimumLength =7, ErrorMessage ="Student Code is Seven Charachters")]
        [Display(Name = "Student Code")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Is Graduated is Required")]
        [Display(Name = "Is Graduated")]
        public bool IsGraduated { get; set; }

        [Required(ErrorMessage = "Field is Required")]
        [Display(Name = "Field")]
        public int FieldId { get; set; }


        public virtual Field Field { get; set; }
    }
}