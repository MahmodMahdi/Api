using Microsoft.AspNetCore.Mvc;
using UserAndCourse.Context;
using UserAndCourse.Models;
using UserAndCourse.ViewModel;

namespace UserAndCourse.Controllers
{
	public class CoursesController : Controller
	{
		private readonly ApplicationContext _context;
        public CoursesController(ApplicationContext context)
        {
            _context = context;
        }
		//public CoursesController()   // old way
		//{
		//    _context = new AplicationContext();
		//}
		public IActionResult Index()
		{
			var courses= _context.Courses.ToList();
			return View(courses);
		}
		public IActionResult Details(int id)
		{
			var course = _context.Courses.SingleOrDefault(c => c.Id == id);
			CourseViewModel courseVM = new CourseViewModel()
			{
				Id = course!.Id,
				Name = course.Name,
				Hours = course.Hours,
				Description = course.Description,
				Price = course.Price,
				//Users = course.Users
			};
			ViewBag.courseName = _context.Courses.FirstOrDefault(c => c.Id == courseVM.Id);
			return View(courseVM) ;
		}
		public IActionResult Delete(int id)
		{
			var courseToDelete = _context.Courses.FirstOrDefault(c => c.Id == id);
			if(courseToDelete is not null)
				_context.Courses.Remove(courseToDelete);
			
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public	IActionResult Add()
		{
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course courseVM)
		{
            if (!ModelState.IsValid)
            {
                return View();
            }
			_context.Courses.Add(courseVM);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Edit(int id) 
		{
			var courseToEdit = _context.Courses.FirstOrDefault(c => c.Id == id);
			CourseViewModel courseVM = new()
			{
				Id = courseToEdit!.Id,
                Name =courseToEdit.Name,
                Description = courseToEdit.Description,
                Price = courseToEdit.Price,
                Hours = courseToEdit.Hours
            };
            return View(courseVM);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseViewModel CourseVM)
		{
			 var courseToEdit = _context.Courses.Single(c=>c.Id == CourseVM.Id);

            courseToEdit.Id = CourseVM.Id;
            courseToEdit.Name = CourseVM.Name!;
            courseToEdit.Description = CourseVM.Description;
            courseToEdit.Price = CourseVM.Price;
            courseToEdit.Hours = CourseVM.Hours;
            _context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Search(string searchString)
		{
			//ViewBag.CurrentFilter = searchString;
			//var ins = from i in _context.Courses
			//		  select i;
			//if (!String.IsNullOrEmpty(searchString))
			//{
			//	ins = ins.Where(i => i.Name.Contains(searchString));
			//}
			//return View(ins);
			var item = _context.Courses.Where(x=>x.Name==searchString).ToList();
			//ViewBag.SearchString = searchString;
			return View(item);
		}
	}
}
