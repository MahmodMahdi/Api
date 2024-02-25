using System.ComponentModel.DataAnnotations;

namespace UserAndCourse.Models
{
	public class Course
	{
		public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public int Hours { get; set; }
		public string? Description { get; set; }
		public int Price { get; set; }

		#region Navigation - Relation
		public List<User>? Users { get; set; } = new List<User>();
		#endregion
	}
}
