using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModel
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<CompetencyHeader> CompetencyHeaders{ get; set; }
    }
}