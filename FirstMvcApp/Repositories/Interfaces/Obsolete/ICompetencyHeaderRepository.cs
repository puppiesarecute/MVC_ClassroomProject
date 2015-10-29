using FirstMvcApp.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FirstMvcApp.Repositories
{
    public interface ICompetencyHeaderRepository
    {
        IQueryable<CompetencyHeader> CompetencyHeaders { get; }
        IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties);
        void Delete(int id);
        CompetencyHeader Find(int id);
        void InsertOrUpdate(CompetencyHeader header);
        void Save();
        void Dispose();
    }
}
