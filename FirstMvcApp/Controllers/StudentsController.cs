using FirstMvcApp.Models;
using FirstMvcApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository studentRepo;

        public StudentsController(IStudentsRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet]
        public ActionResult Edit(int studentId) 
        {
            // look up student in db
            Student student = studentRepo.Find(studentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image) 
        {
            if(ModelState.IsValid)
            {
                student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                studentRepo.InsertOrUpdate(student);
                return RedirectToAction("Index");
            }            
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                studentRepo.InsertOrUpdate(student);
                return RedirectToAction("Index");
                // alternative (not recommendable because if we change the list in View we have to change it here too):
                // return View("Index"), db.Students.ToList();
            }
            return View();
        }

        public ActionResult Index()
        {
            IEnumerable<Student> students = studentRepo.All.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            Student student = studentRepo.Find(studentId);
            studentRepo.Delete(student);
            return RedirectToAction("Index");
        }
    }
}