using FirstMvcApp.Models;
using System;
using System.Linq;
namespace FirstMvcApp.Repositories
{
    public interface ICompetencyHeaderRepository
    {
        IQueryable<CompetencyHeader> CompetencyHeaders { get; }
        void Delete(int id);
        CompetencyHeader Find(int id);
        void InsertOrUpdate(CompetencyHeader header);
        void Save();
        void Dispose();
    }
}
