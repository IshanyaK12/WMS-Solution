using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Leave {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeaveId { get; set; }

    [Required]
    public int EmpId { get; set; }
    public Employee Applicant { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    [StringLength(30, ErrorMessage = "Leave type must be less than 30 characters")]
    public string LeaveType { get; set; } = string.Empty;

    [Column(TypeName = "varchar(255)")]
    [StringLength(255, ErrorMessage = "Reason must be less than 255 characters")]
    public string? Reason { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly FromDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly ToDate { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, ErrorMessage = "Status must be less than 20 characters")]
    public string Status { get; set; } = "Pending";

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime AppliedOn { get; set; }

    public int? ApprovedBy { get; set; }
    public Employee? Approver { get; set; }

    public DateTime? ApprovedOn { get; set; }
  }
}