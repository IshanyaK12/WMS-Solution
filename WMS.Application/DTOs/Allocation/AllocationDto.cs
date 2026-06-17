namespace WMS.Application.DTOs.Allocation {
  public record AllocationDto(int AllocationId, int EmpId, string? AllocatedEmployee, int ProjectId, string? AllocatedProject, DateOnly AssignedOn, bool Status, string UpdatedBy, DateOnly UpdatedDate);
}