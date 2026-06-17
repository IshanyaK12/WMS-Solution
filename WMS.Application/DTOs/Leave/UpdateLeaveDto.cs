using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Leave {
  public record UpdateLeaveDto {
    [Required][MaxLength(20)] public string Status { get; init; }
    public int? ApprovedBy { get; init; }
  }
}