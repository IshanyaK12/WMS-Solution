namespace WMS.Application.DTOs.Department {
  public record DepartmentDto(int DepartmentId, string DepartmentName, string? Description, DateTime CreatedOn);
}