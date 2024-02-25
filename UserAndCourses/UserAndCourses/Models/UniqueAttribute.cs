using System.ComponentModel.DataAnnotations;
using UserAndCourse.Context;

namespace UserAndCourse.Models
{
	public class UniqueAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			ApplicationContext application = new ApplicationContext();
			string? name = value?.ToString() ;
		
			var course = application.Courses.FirstOrDefault(c => c.Name == name);
			if (course == null)
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("Name already exist");
		}
	}
}
