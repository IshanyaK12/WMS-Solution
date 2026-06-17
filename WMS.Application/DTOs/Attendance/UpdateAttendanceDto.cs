using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Attendance {
  public record UpdateAttendanceDto {
    public TimeSpan? CheckOutTime { get; init; }
    [Required][MaxLength(20)] public string Status { get; init; }
  }
}