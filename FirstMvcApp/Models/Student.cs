using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FirstMvcApp.ModelHelper;

namespace FirstMvcApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student must have a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Student must have a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Phone number must have at least {0} digits")]
        [MaxLength(12, ErrorMessage = "Phone number can not exceed {0} digits")]
        public string Phone { get; set; }

        public string ProfileImagePath { get; set; }

        public virtual ICollection<Competency> Competencies { get; set; }

        public Education Education { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;

            if (!String.IsNullOrEmpty(this.ProfileImagePath))
            {
                // delete the old picture before adding new picture
                ImageModel.DeleteFile(serverPath + ProfileImagePath);
            }
            //ImageModel
            Guid guid = Guid.NewGuid();
            ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

            ProfileImagePath = pathToFile + guid.ToString() + ".jpg";
        }
    }
}