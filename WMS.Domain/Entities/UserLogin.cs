using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class UserLogin {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, ErrorMessage = "Username must be less than 50 characters")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(max)")]
    public string PasswordHash { get; set; } = string.Empty;

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public DateTime? LastLogin { get; set; }
  }
}