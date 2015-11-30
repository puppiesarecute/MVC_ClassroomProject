using FirstMvcApp.Models;
using FirstMvcApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FirstMvcApp.Repositories
{
    public class CompetencyRepository : IRepository<Competency>
    {
        ApplicationDbContext context;

        public CompetencyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Competency> All
        {
            get

            {
                return context.Competencies;
            }
        }

        public IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = context.Competencies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Competency Find(int id)
        {
            return context.Competencies.Find(id);
        }

        // TODO fix exception - An entity object cannot be referenced by multiple instances of IEntityChangeTracker.
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

        public void Delete(Competency student)
        {
            throw new NotImplementedException();
        }
    }


}