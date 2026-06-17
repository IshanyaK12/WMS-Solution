using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Announcement {
  public record UpdateAnnouncementDto {
    [Required][MaxLength(100)] public string Title { get; init; }
    [Required] public string Message { get; init; }
    [Required] public bool IsActive { get; init; }
  }
}