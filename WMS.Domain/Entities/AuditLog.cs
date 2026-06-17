using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class AuditLog {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditId { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string EntityName { get; set; } = string.Empty;

    public int RecordId { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, ErrorMessage = "Action must be less than 20 characters")]
    public string Action { get; set; } = string.Empty;

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
  }
}