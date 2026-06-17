using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTO.Project {
  public record UpdateProjectDto {
    [Required][MaxLength(100)] public string ProjectName { get; init; }
    public string? Description { get; init; }
    [Required] public int ClientId { get; init; }
    [Required] public DateOnly StartDate { get; init; }
    public DateOnly? EndDate { get; init; }
    [Required][MaxLength(20)] public string Status { get; init; }
  }
}