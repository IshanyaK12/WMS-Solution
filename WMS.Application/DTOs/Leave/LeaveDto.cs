namespace WMS.Application.DTOs.Leave {
  public record LeaveDto(int LeaveId, int EmpId, string? EmployeeName, string LeaveType, DateOnly StartDate, DateOnly EndDate, string Reason, string Status, int? ApprovedBy, string? Approver, DateOnly AppliedOn);
}