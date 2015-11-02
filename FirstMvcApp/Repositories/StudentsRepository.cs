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
        ApplicationDbContext context;

        public StudentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

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

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == 0) //new
            {
                context.Students.Add(student);
            }
            else //edit
            {             
                //Update the competencies
                //get the student include list of competencies from db
                var existingstudent = context.Students.Include(y => y.Competencies).Include(e => e.Education).SingleOrDefault(x => x.StudentId == student.StudentId);
                var test = context.Entry(student);

                if (existingstudent == null)
                    throw new Exception(string.Format("No student found with StudentId {0}", student.StudentId));

                //get the newly added competencies that are not in the existing competencies
                var newComps = student.Competencies.Except(existingstudent.Competencies);

                //get the competencies to be deleted 
                var deleteComps = existingstudent.Competencies.Except(student.Competencies);

                foreach (var comp in deleteComps.ToArray())
                    existingstudent.Competencies.Remove(comp);

                foreach (var comp in newComps)
                {
                    if (context.Entry(comp).State == EntityState.Detached)
                        context.Competencies.Attach(comp);

                    existingstudent.Competencies.Add(comp);
                }

                //Update the Education
                if (existingstudent.Education.EducationId != student.Education.EducationId)
                {
                    existingstudent.Education = student.Education;
                    if (context.Entry(student.Education).State == EntityState.Detached)
                        context.Educations.Attach(existingstudent.Education);
                }

                //TODO fix this error!!!
                //test.State = EntityState.Modified;
            }

            this.Save();
            context.Entry(student).State = EntityState.Modified;
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