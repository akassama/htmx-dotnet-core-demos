using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTMXApplication.Models
{
    [Table("HX_Users", Schema = "dbo")]
    public class UsersModel
    {
        [Key]
        [Display(Name = "User ID")]
        public Guid UserID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone is required")]
        public string? PhoneNumber { get; set; } = null;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "D.O.B is required")]
        public DateTime? DateOfBirth { get; set; } = null;

        [Display(Name = "Delete Status")]
        public bool DeleteStatus { get; set; } = false;

        [Display(Name = "Status")]
        public int Status { get; set; } = 0;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
