using AutoMapper;
using Enrollment.App.Repositories;
using Enrollment.App.ViewModels;
using Enrollment.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()    //View All
        {
            //List<StudentVM> svmlist = mapper.Map<List<StudentVM>>(
            //    context.Students.ToList());

            return View(mapper.Map<List<StudentVM>>(
                await repo.GetAllAsync()));
        }

        public IActionResult Add()
        {
            StudentVM model = new StudentVM();
            model.AdmissionDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StudentVM model)
        {
            if (ModelState.IsValid == true)
            {
                //Save the student
                //model.AdmissionDate = DateTime.Now;
                await repo.AddAsync(mapper.Map<Student>(model));

                return RedirectToAction("Index");
            }
            else
            {
                //Prompt an error
                return View(model);
            }
        }
    }
}
