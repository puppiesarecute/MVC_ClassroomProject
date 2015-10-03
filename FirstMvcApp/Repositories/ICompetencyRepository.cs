using FirstMvcApp.Models;
using System;
using System.Linq;
namespace FirstMvcApp.Repositories
{
    public interface ICompetencyRepository
    {
        IQueryable<Competency> Competencies { get; }
        void Delete(int id);
        Competency Find(int id);
        void InsertOrUpdate(Competency cpt);
        void Save();
        void Dispose();
    }
}
