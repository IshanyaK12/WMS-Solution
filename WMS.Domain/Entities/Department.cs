using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Department {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, ErrorMessage = "Department name must be less than 100 characters")]
    public string DepartmentName { get; set; } = string.Empty;

    [Column(TypeName = "varchar(255)")]
    [StringLength(255, ErrorMessage = "Department description must be less than 255 characters")]
    public string? Description { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
  }
}