using Microsoft.EntityFrameworkCore;
using UserAndCourse.Context;

namespace UserAndCourse
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            #region Services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
			#endregion
			//var connString = "Server=DESKTOP-4KE09AR;Database=UdemyDB;Trusted_Connection=True;Encrypt=False";  //here wrong way because it will show in il
			var connString = builder.Configuration.GetConnectionString("DB");
			builder.Services.AddDbContext<ApplicationContext>(options => 
			options.UseSqlServer(connString));
            var app = builder.Build();
            #region Middlewarss
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
            #endregion
        }
    }
}