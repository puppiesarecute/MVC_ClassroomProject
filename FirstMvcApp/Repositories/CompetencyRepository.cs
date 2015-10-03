using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Repositories
{
    public class CompetencyRepository : ICompetencyRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Competency> Competencies
        {
            get { return context.Competencies; }
        }

        public Competency Find(int id)
        {
            return context.Competencies.Find(id);
        }

        public void InsertOrUpdate(Competency cpt)
        {
            if (cpt.CompetencyId == 0) //new
            {
                context.Competencies.Add(cpt);
            }
            else //edit
            {
                context.Entry(cpt).State = EntityState.Modified;
            }
            this.Save();
        }

        public void Delete(int id)
        {
            context.Competencies.Remove(this.Find(id));
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }


}