using System.ComponentModel.DataAnnotations;

namespace UserAndCourse.Models
{
	public class Login
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "*")]
		[DataType(DataType.EmailAddress)]
		[RegularExpression("[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,100}", ErrorMessage = "Enter valid Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "*")]
		[MinLength(8, ErrorMessage = "Password must be greater than 7 letters"),MaxLength(32)]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
