using AutoMapper;
using WMS.Application.DTOs.Employee;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;

namespace WMS.Application.Services {
  public class EmployeeService : IEmployeeService {
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper) {
      _employeeRepository = employeeRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync() {
      var employeeList = await _employeeRepository.GetAllAsync(
          includes: [e => e.Department, e => e.Role]
        );
      return _mapper.Map<IEnumerable<EmployeeDto>>(employeeList);
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id) {
      var existingEmployee = await _employeeRepository.GetFirstOrDefaultAsync(
          e => e.EmployeeId == id,
          includes: [e => e.Department, e => e.Role]
        );
      return existingEmployee == null ? null : _mapper.Map<EmployeeDto>(existingEmployee);
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto) {
      var employee = _mapper.Map<Employee>(createEmployeeDto);
      await _employeeRepository.AddAsync(employee);
      await _employeeRepository.SaveChangesAsync();
      return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto) {
      var existingEmployee = await _employeeRepository.GetByIdAsync(id);
      if (existingEmployee == null) {
        return false;
      }
      _mapper.Map(updateEmployeeDto, existingEmployee);
      _employeeRepository.Update(existingEmployee);
      return true;
    }

    public async Task<bool> DeactiveEmployeeAsync(int id) {
      var existingEmployee = await _employeeRepository.GetByIdAsync(id);
      if (existingEmployee == null)
        return false;
      existingEmployee.Status = "Inactive";
      await _employeeRepository.SaveChangesAsync();
      return true;
    }

    public async Task<IEnumerable<EmployeeDto>> SearchByNameAsync(string name) {
      var foundEmployees = await _employeeRepository.FindAsync(
        e => (e.Firstname.Contains(name) || e.Lastname.Contains(name)),
        includes: [e => e.Role, e => e.Department]
      );
      return _mapper.Map<IEnumerable<EmployeeDto>>(foundEmployees);
    }

    public async Task<IEnumerable<EmployeeDto>> SearchByDepartmentNameAsync(string departmentName) {
      var foundEmployees = await _employeeRepository.FindAsync(
        e => e.Department.DepartmentName.Contains(departmentName),
        includes: [e => e.Role, e => e.Department]
      );
      return _mapper.Map<IEnumerable<EmployeeDto>>(foundEmployees);
    }

    public async Task<IEnumerable<EmployeeDto>> SearchByRoleNameAsync(string roleName) {
      var foundEmployees = await _employeeRepository.FindAsync(
        e => e.Role.RoleName.Contains(roleName),
        includes: [e => e.Role, e => e.Department]
      );
      return _mapper.Map<IEnumerable<EmployeeDto>>(foundEmployees);
    }
  }
}
