namespace WMS.Application.DTOs.UserLogin {
  public record UserLoginDto(int UserId, string Username, int RoleId, string? RoleName, DateTime? LastLogin);
}