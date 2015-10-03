using FirstMvcApp.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace FirstMvcApp.Repositories
{
    public interface IStudentsRepository
    {
        IQueryable<Student> All { get; }
        IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties);
        void Delete(Student student);
        Student Find(int id);
        void InsertOrUpdate(Student student);
        void Save();
    }
}
