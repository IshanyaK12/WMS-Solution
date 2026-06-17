using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Announcement {
  public record CreateAnnouncementDto {
    [Required][MaxLength(100)] public string Title { get; init; }
    [Required] public string Message { get; init; }
    [Required] public int CreatedBy { get; init; }
  }
}