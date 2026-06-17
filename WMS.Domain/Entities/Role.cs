using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Role {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "Role name must be less than 50 characters")]
    public string RoleName { get; set; } = string.Empty;

    [Column(TypeName = "varchar(150)")]
    [StringLength(150, ErrorMessage = "Description must be less than 150 characters")]
    public string? Description { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<UserLogin> Users { get; set; } = new List<UserLogin>();
  }
}