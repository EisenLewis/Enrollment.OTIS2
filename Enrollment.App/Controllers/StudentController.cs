using AutoMapper;
using Enrollment.App.ViewModels;
using Enrollment.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public StudentController(AppDbContext _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }

        public IActionResult Index()    //View All
        {
            //List<StudentVM> svmlist = mapper.Map<List<StudentVM>>(
            //    context.Students.ToList());

            return View(mapper.Map<List<StudentVM>>(
                context.Students.ToList()));
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
                await context.Set<Student>()
                    .AddAsync(mapper.Map<Student>(model));
                await context.SaveChangesAsync();

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
