using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        [Required]
        public string EducationName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}