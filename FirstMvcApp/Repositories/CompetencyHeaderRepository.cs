using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Repositories
{
    public class CompetencyHeaderRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<CompetencyHeader> CompetencyHeaders
        {
            get { return context.CompetencyHeaders; }
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

        public void Delete(CompetencyHeader header)
        {
            context.CompetencyHeaders.Remove(header);
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        internal void Dispose()
        {
            if (context !=null)
            {
                context.Dispose();
            }
        }
    }
}