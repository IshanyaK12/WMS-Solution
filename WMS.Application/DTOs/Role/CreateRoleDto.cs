using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Role {
  public record CreateRoleDto {
    [Required][MaxLength(50)] public string RoleName { get; init; }
    [MaxLength(150)] public string? Description { get; init; }
  }
}