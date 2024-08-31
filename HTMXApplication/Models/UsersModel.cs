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
        public string Name { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Gender")]
        public string? Gender { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; } = null;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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
