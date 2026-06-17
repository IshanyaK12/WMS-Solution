namespace WMS.Application.DTOs.Attendance {
  public record AttendanceDto(int AttendanceId, int EmpId, string? EmployeeName, DateOnly Date, TimeSpan CheckInTime, TimeSpan? CheckOutTime, string Status);
}