using FirstMvcApp.Models;
using FirstMvcApp.MyInterface;
using FirstMvcApp.Repositories;
using FirstMvcApp.Repositories.Interfaces;
using FirstMvcApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IEmailer studentEmailer;
        private readonly IRepository<CompetencyHeader> competencyHeaderRepository;
        private readonly IRepository<Competency> competencyRepository;

        public StudentsController(IRepository<Student> studentRepo, IEmailer emailer, IRepository<CompetencyHeader> competencyHeaderRepo, IRepository<Competency> competencyRepo)
        {
            this.studentRepository = studentRepo;
            this.studentEmailer = emailer;
            this.competencyHeaderRepository = competencyHeaderRepo;
            this.competencyRepository = competencyRepo;
        }

        [HttpGet]
        public ActionResult Edit(int studentId) 
        {
            // look up student in db
            Student student = studentRepository.Find(studentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image) 
        {
            if(ModelState.IsValid)
            {
                student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                studentRepository.InsertOrUpdate(student);
                return RedirectToAction("Index");
            }            
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateEditStudentViewModel vm = new CreateEditStudentViewModel
            {
                Student = new Student(),
                CompetencyHeaders = competencyHeaderRepository.AllIncluding(a => a.Competencies).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(CreateEditStudentViewModel data, HttpPostedFileBase image, IEnumerable<int> compIds)
        {
            if (ModelState.IsValid)
            {
                string path = Server != null ? Server.MapPath("~") : "";
                data.Student.SaveImage(image, path, "/ProfileImages/");

                studentRepository.InsertOrUpdate(student);

                //var newIds = compIds.Except(student.Competencies.Select(x => x.CompetencyId));
                //var deleteIds = student.Competencies.Select(x => x.CompetencyId).Except(compIds);

                return RedirectToAction("Index");
                // alternative (not recommendable because if we change the list in View we have to change it here too):
                // return View("Index"), db.Students.ToList();
            }
            return View();
        }

        public ActionResult Index()
        {
            IEnumerable<Student> students = studentRepository.All.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            studentRepository.Delete(studentId);
            return RedirectToAction("Index");
        }
    }
}