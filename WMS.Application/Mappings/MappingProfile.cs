using AutoMapper;
using WMS.Application.DTO.Project;
using WMS.Application.DTOs.Allocation;
using WMS.Application.DTOs.Announcement;
using WMS.Application.DTOs.Attendance;
using WMS.Application.DTOs.AuditLog;
using WMS.Application.DTOs.Client;
using WMS.Application.DTOs.Department;
using WMS.Application.DTOs.Employee;
using WMS.Application.DTOs.Leave;
using WMS.Application.DTOs.Project;
using WMS.Application.DTOs.Role;
using WMS.Application.DTOs.UserLogin;
using WMS.Domain.Entities;

namespace WMS.Application.Mappings {
  public class MappingProfile : Profile {
    public MappingProfile() {
      // EMPLOYEE
      CreateMap<Employee, EmployeeDto>()
        .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
        .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
      CreateMap<CreateEmployeeDto, Employee>();
      CreateMap<UpdateEmployeeDto, Employee>();

      // DEPARTMENT
      CreateMap<Department, DepartmentDto>();
      CreateMap<CreateDepartmentDto, Department>();
      CreateMap<UpdateDepartmentDto, Department>();

      // ROLE
      CreateMap<Role, RoleDto>();
      CreateMap<CreateRoleDto, Role>();
      CreateMap<UpdateRoleDto, Role>();

      // LEAVE
      CreateMap<Leave, LeaveDto>()
        .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Applicant))
        .ForMember(dest => dest.Approver, opt => opt.MapFrom(src => src.Approver));
      CreateMap<CreateLeaveDto, Leave>();
      CreateMap<UpdateLeaveDto, Leave>();

      // PROJECT
      CreateMap<Project, ProjectDto>()
        .ForMember(dest => dest.ClientName, opt => opt.MapFrom(
          src => src.Client != null ? src.Client.ClientName : null
        ));
      CreateMap<CreateProjectDto, Project>();
      CreateMap<UpdateProjectDto, Project>();

      // CLIENT
      CreateMap<Client, ClientDto>();
      CreateMap<CreateClientDto, Client>();
      CreateMap<UpdateClientDto, Client>();

      // ATTENDANCE
      CreateMap<Attendance, AttendanceDto>()
        .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.Firstname} {src.Employee.Lastname}"));
      CreateMap<CreateAttendanceDto, Attendance>();
      CreateMap<UpdateAttendanceDto, Attendance>();

      // ALLOCATION
      CreateMap<Allocation, AllocationDto>()
        .ForMember(dest => dest.AllocatedEmployee, opt => opt.MapFrom(src => $"{src.AllocatedEmployee.Firstname} + {src.AllocatedEmployee.Lastname}"))
        .ForMember(dest => dest.AllocatedProject, opt => opt.MapFrom(src => src.AllocatedProject.ProjectName));
      CreateMap<CreateAnnouncmentDto, Allocation>();
      CreateMap<UpdateAllocationDto, Allocation>();

      // ANNOUNCEMENT
      CreateMap<Announcement, AnnouncementDto>()
        .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => $"{src.Creator.Firstname} {src.Creator.Lastname}"));
      CreateMap<CreateAnnouncementDto, Announcement>();
      CreateMap<UpdateAnnouncementDto, Announcement>();

      // USER LOGIN
      CreateMap<UserLogin, UserLoginDto>()
        .ForMember(src => src.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
      CreateMap<CreateUserLoginDto, UserLogin>();
      CreateMap<UpdateUserLoginDto, UserLogin>();

      // AUDIT LOG
      CreateMap<AuditLog, AuditLogDto>();
    }
  }
}
