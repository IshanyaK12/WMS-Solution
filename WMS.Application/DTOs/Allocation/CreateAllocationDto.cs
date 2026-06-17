using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Allocation {
  public record CreateAllocationDto {
    [Required] public int EmpId { get; init; }
    [Required] public int ProjectId { get; init; }
    [Required] public DateOnly AssignedOn { get; init; }
    [Required] public bool Status { get; init; }
    [Required][MaxLength(50)] public string UpdatedBy { get; init; }
    [Required] public DateOnly UpdatedDate { get; init; }
  }
}