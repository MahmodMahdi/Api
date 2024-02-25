using Microsoft.EntityFrameworkCore;
using UserAndCourse.Models;

namespace UserAndCourse.Context
{
	public class ApplicationContext : DbContext
	{
		 public ApplicationContext() { }
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }  //another way to pass conn string 
		public DbSet<User> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Login> Logins { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//=> optionsBuilder.UseSqlServer("Server=DESKTOP-4KE09AR;Database=UdemyDB;Trusted_Connection=True;Encrypt=False");
	}
}
