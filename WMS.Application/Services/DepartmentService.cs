using AutoMapper;
using WMS.Application.DTOs.Department;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;

namespace WMS.Application.Services {
  public class DepartmentService : IDepartmentService {
    private readonly IRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IRepository<Department> departmentRepository, IMapper mapper) {
      _departmentRepository = departmentRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync() {
      var departmentList = await _departmentRepository.GetAllAsync(d => d.Employees);
      return _mapper.Map<IEnumerable<DepartmentDto>>(departmentList);
    }

    public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id) {
      var department = await _departmentRepository.GetByIdAsync(id);
      return department == null ? null : _mapper.Map<DepartmentDto>(department);
    }

    public async Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createDepartmentDto) {
      var department = _mapper.Map<Department>(createDepartmentDto);
      await _departmentRepository.AddAsync(department);
      await _departmentRepository.SaveChangesAsync();
      return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentDto updateDepartmentDto) {
      var exisitingDepartment = await _departmentRepository.GetByIdAsync(id);
      if (exisitingDepartment == null) {
        return false;
      }
      _mapper.Map(updateDepartmentDto, exisitingDepartment);
      _departmentRepository.Update(exisitingDepartment);
      return true;
    }

    public async Task<bool> DeleteDepartmentAsync(int id) {
      var exisitingDepartment = await _departmentRepository.GetByIdAsync(id);
      if (exisitingDepartment == null) {
        return false;
      }
      _departmentRepository.Delete(exisitingDepartment);
      await _departmentRepository.SaveChangesAsync();
      return true;
    }
  }
}
