using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public string Name { get; set; }
        public int CompetencyHeaderId { get; set; }
        public CompetencyHeader CompetencyHeader { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}