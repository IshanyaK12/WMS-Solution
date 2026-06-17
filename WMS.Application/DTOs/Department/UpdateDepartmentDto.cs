using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Department {
  public record UpdateDepartmentDto {
    [Required][MaxLength(100)] public string DepartmentName { get; init; }
    public string? Description { get; init; }
  }
}