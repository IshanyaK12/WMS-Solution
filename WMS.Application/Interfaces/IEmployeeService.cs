using WMS.Application.DTOs.Employee;

namespace WMS.Application.Interfaces {
  public interface IEmployeeService {
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
    Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);
    Task<bool> DeactiveEmployeeAsync(int id);
    Task<IEnumerable<EmployeeDto>> SearchByNameAsync(string name);
    Task<IEnumerable<EmployeeDto>> SearchByDepartmentNameAsync(string departmentName);
    Task<IEnumerable<EmployeeDto>> SearchByRoleNameAsync(string roleName);
  }
}
