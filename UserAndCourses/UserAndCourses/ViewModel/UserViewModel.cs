using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserAndCourse.Models;

namespace UserAndCourse.ViewModel
{
	public class UserViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "*")]
		[MaxLength(30, ErrorMessage = "Name must be less than 29 letters"), MinLength(2, ErrorMessage = "Name must be greater than 2 letters.")]
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "*")]
		[Range(18, 60, ErrorMessage = "{0} must be {1} to {2}")]
		public int Age { get; set; }
		public string? Address { get; set; } = string.Empty;
		[Required(ErrorMessage = "*")]
		[RegularExpression("01[0125][0-9]{8}", ErrorMessage = "Enter Valid Phone Number.")]
		public string? Phone { get; set; }
		[Required(ErrorMessage = "*")]
		[RegularExpression("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,100}", ErrorMessage = "Enter valid Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "*")]
		[MaxLength(32, ErrorMessage = "Password must be less than 31 letters."), MinLength(8, ErrorMessage = "Password must be greater than 7 letters")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
		[NotMapped]
		[Required(ErrorMessage = "*")]
		[DataType(DataType.Password)]
		[Compare("Password")]

		public string ConfirmPass { get; set; } = string.Empty;
		[DisplayName("Course")]
		public int? CourseId { get; set; }
    }
}