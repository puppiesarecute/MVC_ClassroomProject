using FirstMvcApp.Models;
using FirstMvcApp.Repositories;
using FirstMvcApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FirstMvcApp.Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Student> All
        {
            get { return context.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = context.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Student Find(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<Competency> FindMatchingCompetencies(IEnumerable<int> competencyIds)
        {
            return context.Competencies.Where(x => competencyIds.Contains(x.CompetencyId)).ToList();
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == 0) //new
            {
                context.Students.Add(student);
            }
            else //edit
            {
                context.Entry(student).State = EntityState.Modified;
            }
            this.Save();
        }

        public void Delete(int studentId)
        {
            context.Students.Remove(this.Find(studentId));
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
    }
}