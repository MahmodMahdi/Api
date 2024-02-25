using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAndCourse.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Age { get; set; }
		public string? Address { get; set; } = string.Empty;
		public string? Phone { get; set; }
        public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;  
        public string ConfirmPass { get; set; } = string.Empty;

		#region Navigation - Relation
		[ForeignKey(nameof(Course))]
		public int? CourseId { get; set; }
		public	Course? Course { get; set; }
		#endregion
	}
}
