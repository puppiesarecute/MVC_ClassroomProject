using FirstMvcApp.Models;
using FirstMvcApp.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FirstMvcApp.Repositories
{
    public class EducationRepository : IRepository<Education>
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<Education> All
        {
            get
            {
                return context.Educations;
            }
        }

        public IQueryable<Education> AllIncluding(params Expression<Func<Education, object>>[] includeProperties)
        {
            IQueryable<Education> query = context.Educations;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            context.Educations.Remove(this.Find(id));
            this.Save();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public Education Find(int id)
        {
            return context.Educations.Find(id);
        }

        public void InsertOrUpdate(Education edu)
        {
            if (edu.EducationId == 0) //new
            {
                context.Educations.Add(edu);
            }
            else //edit
            {
                context.Entry(edu).State = EntityState.Modified;
            }
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}