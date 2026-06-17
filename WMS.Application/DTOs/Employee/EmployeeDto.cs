namespace WMS.Application.DTOs.Employee {
  public record EmployeeDto(int EmployeeId, string Firstname, string Lastname, string Email, string PhoneNumber, char Gender, DateOnly DOB, DateOnly DOJ, int DepartmentId, string? DepartmentName, int RoleId, string? RoleName, string Status);
}