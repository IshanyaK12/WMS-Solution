using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.UserLogin {
  public record UpdateUserLoginDto {
    [Required][MaxLength(50)] public string Username { get; init; }
    [Required] public int RoleId { get; init; }
  }
}