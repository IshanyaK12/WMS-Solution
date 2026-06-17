using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Attendance {
  public record CreateAttendanceDto {
    [Required] public int EmpId { get; init; }
    [Required] public DateOnly Date { get; init; }
    [Required] public TimeSpan CheckInTime { get; init; }
    [Required][MaxLength(20)] public string Status { get; init; }
  }
}