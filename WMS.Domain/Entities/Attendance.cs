using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities {
  public class Attendance {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttendanceId { get; set; }

    [Required]
    public int EmpId { get; set; }
    public Employee Employee { get; set; }

    [Required]
    public DateTime CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    // SQL Server float is max 64-bit & C# double is 64-bit
    [Column(TypeName = "float")]
    public double TotalHours { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? WorkMode { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateOnly AttendanceDate { get; set; }
  }
}