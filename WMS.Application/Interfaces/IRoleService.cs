using WMS.Application.DTOs.Role;

namespace WMS.Application.Interfaces {
  public interface IRoleService {
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto?> GetRoleByIdAsync(int id);
  }
}
