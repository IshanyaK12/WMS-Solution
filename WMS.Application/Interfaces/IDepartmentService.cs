using WMS.Application.DTOs.Department;

namespace WMS.Application.Interfaces {
  public interface IDepartmentService {
    Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
    Task<DepartmentDto?> GetDepartmentByIdAsync(int id);
    Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createDepartmentDto);
    Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentDto updateDepartmentDto);
    Task<bool> DeleteDepartmentAsync(int id);
  }
}
