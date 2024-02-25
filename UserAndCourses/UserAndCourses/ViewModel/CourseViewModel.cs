using System.ComponentModel.DataAnnotations;
using UserAndCourse.Models;

namespace UserAndCourse.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }
		[Unique]
		[Required(ErrorMessage = "*")]
        [MaxLength(30, ErrorMessage = "Name must be less than 29 letters"), MinLength(3, ErrorMessage = "Name must be greater than 2 letters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 500, ErrorMessage = "{0} from {1} to {2}")]
        public int Hours { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("[A-Za-z_ ]{2,64}", ErrorMessage = "Range between 2 to 100 letters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(10, 10000)]
        public int Price { get; set; }

        #region Navigation - Relation
     //   public List<User>? Users { get; set; } = new List<User>();
        #endregion
    }
}
