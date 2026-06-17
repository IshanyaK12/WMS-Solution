namespace WMS.Application.DTOs.Announcement {
  public record AnnouncementDto(int AnnouncementId, string Title, string Message, int CreatedBy, string? CreatorName, DateTime CreatedOn, bool IsActive);
}