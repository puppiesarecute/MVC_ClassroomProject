using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public string Name { get; set; }
        public int CompetencyHeaderId { get; set; }
        public virtual CompetencyHeader CompetencyHeader { get; set; }
    }
}