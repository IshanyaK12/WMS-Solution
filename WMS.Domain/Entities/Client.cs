using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Client {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClientId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    [StringLength(100, ErrorMessage = "Client name must be less than 100 characters")]
    public string ClientName { get; set; } = string.Empty;

    [Column(TypeName = "varchar(max)")]
    public string? ClientAddress { get; set; }

    [Column(TypeName = "numeric(10,0)")]
    public decimal? ClientPhoneNumber { get; set; }

    [Column(TypeName = "varchar(20)")]
    [StringLength(20, ErrorMessage = "Client location must be less than 20 characters")]
    public string? ClientLocation { get; set; }

    [Column(TypeName = "bit")]
    public bool Status { get; set; } = true;

    public ICollection<Project> Projects { get; set; } = new List<Project>();
  }
}