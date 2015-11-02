using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using FirstMvcApp.Repositories.Interfaces;

namespace FirstMvcApp.Repositories
{
    public class CompetencyHeaderRepository : IRepository<CompetencyHeader>
    {
        ApplicationDbContext context;

        public CompetencyHeaderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<CompetencyHeader> All
        {
            get
            {
                return context.CompetencyHeaders;
            }
        }

        public IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = context.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CompetencyHeader Find(int id)
        {
            return context.CompetencyHeaders.Find(id);
        }

        public void InsertOrUpdate(CompetencyHeader header)
        {
            if (header.CompetencyHeaderId == 0) //new
            {
                context.CompetencyHeaders.Add(header);
            }
            else //edit
            {
                context.Entry(header).State = EntityState.Modified;
            }
            this.Save();
        }

        public void Delete(int id)
        {
            context.CompetencyHeaders.Remove(this.Find(id));
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context !=null)
            {
                context.Dispose();
            }
        }

    }
}