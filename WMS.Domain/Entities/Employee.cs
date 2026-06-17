using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS.Domain.Attributes;

namespace WMS.Domain.Entities {
  public class Employee {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "First name must be less than 50 characters")]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "Last name must be less than 50 characters")]
    public string Lastname { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    [Column(TypeName = "varchar(80)")]
    [StringLength(80, ErrorMessage = "Email must be less than 80 characters")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.PhoneNumber)]
    [Column(TypeName = "varchar(15)")]
    [StringLength(15, ErrorMessage = "Phone number must be less than 15 characters")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column(TypeName = "char(1)")]
    [RegularExpression("^[MFO]$", ErrorMessage = "The gender must be M, F or O")]
    public char Gender { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [MinimumAge(18)]
    public DateOnly DOB { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly DOJ { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    [Required(ErrorMessage = "Role id is required")]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, ErrorMessage = "Status must be less than 20 characters")]
    public string Status { get; set; } = "Active";

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<Leave> AppliedLeaves { get; set; } = new List<Leave>();
    public ICollection<Leave> ApprovedLeaves { get; set; } = new List<Leave>();
    public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
    public ICollection<Allocation> Allocations { get; set; } = new List<Allocation>();
  }
}