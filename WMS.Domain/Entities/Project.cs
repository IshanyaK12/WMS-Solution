using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Project {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, ErrorMessage = "Project Name must be less than 100 characters")]
    public string ProjectName { get; set; } = string.Empty;

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly? StartDate { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, ErrorMessage = "Status must be less than 20 characters")]
    public string Status { get; set; } = "Active";

    public ICollection<Allocation> Allocations { get; set; } = new List<Allocation>();
  }
}