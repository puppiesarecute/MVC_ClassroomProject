using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class CompetencyHeader
    {
        public int CompetencyHeaderId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Competency> Competencies { get; set; } // the "virtual" keyword allows for lazy loading - which means it only loads the whole list when absolutely required - compared to eager loading
    }
}