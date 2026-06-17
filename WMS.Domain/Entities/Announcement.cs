using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Announcement {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnnouncementId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(max)")]
    public string Message { get; set; } = string.Empty;

    [Required]
    public int CreatedBy { get; set; }
    public Employee Creator { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "bit")]
    public bool IsActive { get; set; } = true;
  }
}