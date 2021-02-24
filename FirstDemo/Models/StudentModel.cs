using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Models
{
    public class StudentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Display(Name = "Address :")]
        [Required(ErrorMessage = "Address is required.")]
        
        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "DOB is required.")]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }
        public int GenderId { get; set; }
        public bool IsMovie { get; set; }
        public bool IsCricket { get; set; }


    }


    public class Gender
    {
        public string Male { get; set; }
        public string Female { get; set; }
        
    }
}