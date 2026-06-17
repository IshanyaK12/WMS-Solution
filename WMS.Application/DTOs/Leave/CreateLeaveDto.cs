using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Leave {
  public record CreateLeaveDto {
    [Required] public int EmpId { get; init; }
    [Required][MaxLength(50)] public string LeaveType { get; init; }
    [Required] public DateOnly StartDate { get; init; }
    [Required] public DateOnly EndDate { get; init; }
    [Required] public string Reason { get; init; }
  }
}