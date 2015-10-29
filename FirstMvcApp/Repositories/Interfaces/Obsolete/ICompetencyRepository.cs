using FirstMvcApp.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FirstMvcApp.Repositories
{
    public interface ICompetencyRepository
    {
        IQueryable<Competency> Competencies { get; }
        IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties);
        void Delete(int id);
        Competency Find(int id);
        void InsertOrUpdate(Competency cpt);
        void Save();
        void Dispose();
    }
}
