using WMS.Application.DTOs.Attendance;

namespace WMS.Application.Interfaces {
  public interface IAttendanceService {
    Task<IEnumerable<AttendanceDto>> GetAttendanceAsync();
    Task<AttendanceDto?> GetAttendanceByIdAsync(int id);
  }
}
