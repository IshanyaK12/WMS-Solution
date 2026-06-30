using AutoMapper;
using WMS.Application.DTOs.Role;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;

namespace WMS.Application.Services {
  public class RoleService : IRoleService {
    private readonly IRepository<Role> _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRepository<Role> roleRepository, IMapper mapper) {
      _roleRepository = roleRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync() {
      var roleList = await _roleRepository.GetAllAsync();
      return _mapper.Map<IEnumerable<RoleDto>>(roleList);
    }

    public async Task<RoleDto?> GetRoleByIdAsync(int id) {
      var role = await _roleRepository.GetByIdAsync(id);
      return role == null ? null : _mapper.Map<RoleDto>(role);
    }
  }
}
