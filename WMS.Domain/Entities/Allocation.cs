using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Allocation {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AllocationId { get; set; }

    [Required]
    public int EmpId { get; set; }
    public Employee AllocatedEmployee { get; set; }

    [Required]
    public int ProjectId { get; set; }
    public Project AllocatedProject { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly AssignedOn { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly CreatedDate { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "Created By must be less than 50 characters")]
    public string CreatedBy { get; set; } = string.Empty;

    [Column(TypeName = "bit")]
    public bool Status { get; set; } = true;

    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "Updated By must be less than 50 characters")]
    public string? UpdatedBy { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly? UpdatedDate { get; set; }
  }
}