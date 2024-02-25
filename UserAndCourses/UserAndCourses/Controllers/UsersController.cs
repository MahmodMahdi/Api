using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserAndCourse.Context;
using UserAndCourse.Models;
using UserAndCourse.ViewModel;

namespace UserAndCourse.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationContext _context;
		public UsersController(ApplicationContext context)
		{
			// _context = new AplicationContext(); //old way
			_context = context;
		}
        public IActionResult Index()
		{
			var users = _context.Users.ToList();
			return View(users);
		}
		public IActionResult Details(int id)
		{
			var user = _context.Users.Include(u => u.Course).SingleOrDefault( u=>u.Id == id);
			UserViewModel UserVM = new UserViewModel()
			{
				Id = user!.Id,
				Name = user.Name,
				Age = user.Age,
				Address = user.Address,
				Phone = user.Phone,
				Email = user.Email,
				Password = user.Password,
				ConfirmPass = user.ConfirmPass,
				CourseId = user.CourseId,
			};
			ViewBag.CourseName = _context.Courses.FirstOrDefault(c => c.Id == UserVM.CourseId);
			_context.SaveChanges();
			return View (UserVM);
		}
		public IActionResult Delete(int id)
		{
			var userToDelete = _context.Users.FirstOrDefault(c => c.Id == id);
			if (userToDelete is not null)
				_context.Users.Remove(userToDelete);

			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Add()
		{
            GetUserListItems();

            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(UserViewModel UserVm)
		{
			if (!ModelState.IsValid)
			{
				GetUserListItems();
				return View();
			}
			//way to add
			User userToAdd = new()
			{
				Name = UserVm.Name,
				Age = UserVm.Age,
				Address = UserVm.Address,
				Email = UserVm.Email,
				Phone = UserVm.Phone,
				CourseId= UserVm.CourseId,
				Password= UserVm.Password,
				ConfirmPass= UserVm.ConfirmPass
			};
			_context.Users.Add(userToAdd);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
        [HttpGet]
      
        public IActionResult Edit(int id)
        {
			var userToEdit = _context.Users.FirstOrDefault(u => u.Id == id);
			UserViewModel UserVM = new()
			{
				Name = userToEdit!.Name,
				Age = userToEdit.Age,
				Address = userToEdit.Address,
				Email = userToEdit.Email,
				Phone = userToEdit.Phone,
				CourseId = userToEdit.CourseId,
				Password = userToEdit.Password,
				ConfirmPass = userToEdit.ConfirmPass
			};
			GetUserListItems();
            return View(UserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
			
                GetUserListItems();
                return View();
            }
            var userToEdit = _context.Users.Single(c => c.Id == user.Id);

            userToEdit.Name = user.Name;
            userToEdit.Age = user.Age;
			userToEdit.Address = user.Address;
			userToEdit.Phone = user.Phone;
			userToEdit.Email = user.Email;
			userToEdit.CourseId = user.CourseId;
			userToEdit.Password = user.Password;
			userToEdit.ConfirmPass = user.ConfirmPass;
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
			var item = _context.Users.Where(x => x.Name == searchString).ToList();
			//ViewBag.SearchString = searchString;
			return View(item);
		}
		#region Helpers
		private void GetUserListItems()
        {
            var courseListItem = _context.Courses
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()));
            ViewBag.courses = courseListItem;
        }
        #endregion
    }
}
