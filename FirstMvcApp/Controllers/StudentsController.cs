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
        private readonly IRepository<Education> educationRepository;

        public StudentsController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            this.studentRepository = new StudentsRepository(context);
            this.competencyHeaderRepository = new CompetencyHeaderRepository(context);
            this.competencyRepository = new CompetencyRepository(context);
            this.educationRepository = new EducationRepository(context);
        }

        //public StudentsController(IRepository<Student> studentRepo, IEmailer emailer, IRepository<CompetencyHeader> competencyHeaderRepo, IRepository<Competency> competencyRepo)
        //{
        //    this.studentRepository = studentRepo;
        //    this.studentEmailer = emailer;
        //    this.competencyHeaderRepository = competencyHeaderRepo;
        //    this.competencyRepository = competencyRepo;
        //}

        [HttpGet]
        public ActionResult Edit(int studentId) 
        {
            // look up student in db
            Student student = studentRepository.Find(studentId);
            CreateEditStudentViewModel vm = new CreateEditStudentViewModel
            {
                Student = student,
                CompetencyHeaders = competencyHeaderRepository.AllIncluding(a => a.Competencies).ToList(),
                Edu = educationRepository.All.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditStudentViewModel vm, HttpPostedFileBase image, IEnumerable<int> compIds, int eduId) 
        {
            if(ModelState.IsValid)
            {
                saveStudentWithImageAndCompetency(vm.Student, image, compIds, eduId);
                return RedirectToAction("Index");
            }
            return View();
        }

        private void saveStudentWithImageAndCompetency(Student student, HttpPostedFileBase image, IEnumerable<int> compIds, int eduId)
        {
            string path = Server != null ? Server.MapPath("~") : "";
            student.SaveImage(image, path, "/ProfileImages/");

            // saves competencies
            student.Competencies = competencyRepository.All.Where(x => compIds.Contains(x.CompetencyId)).ToList();
            
            // saves education
            student.Education = educationRepository.Find(eduId);

            studentRepository.InsertOrUpdate(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateEditStudentViewModel vm = new CreateEditStudentViewModel
            {
                Student = new Student(),
                CompetencyHeaders = competencyHeaderRepository.AllIncluding(a => a.Competencies).ToList(),
                Edu = educationRepository.All.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(CreateEditStudentViewModel data, HttpPostedFileBase image, IEnumerable<int> compIds, int eduId)
        {
            if (ModelState.IsValid)
            {
                saveStudentWithImageAndCompetency(data.Student, image, compIds, eduId);
                studentRepository.InsertOrUpdate(data.Student);

                return RedirectToAction("Index");
                // alternative (not recommendable because if we change the list in View we have to change it here too):
                // return View("Index"), db.Students.ToList();
            }
            return View();
        }

        public ActionResult Index()
        {
            StudentIndexViewModel svm = new StudentIndexViewModel
            {
                Students = studentRepository.All.ToList(),
                CompetencyHeaders = competencyHeaderRepository.All.ToList()
            };
            return View(svm);
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            studentRepository.Delete(studentId);
            return RedirectToAction("Index");
        }

        //public ActionResult GridExample()
        //{
        //    return View();
        //}
    }
}