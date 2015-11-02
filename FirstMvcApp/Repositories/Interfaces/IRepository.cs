using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FirstMvcApp.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        void Delete(int id);
        T Find(int id);
        void InsertOrUpdate(T type);
        void Save();
        void Dispose();
    }
}
