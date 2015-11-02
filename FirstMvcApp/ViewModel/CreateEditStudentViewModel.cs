using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModel
{
    public class CreateEditStudentViewModel
    {
        public Student Student { get; set; }
        public ICollection<CompetencyHeader> CompetencyHeaders { get; set; }
        public ICollection<Education> Edu { get; set; }
    }
}