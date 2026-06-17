namespace WMS.Application.DTOs.Project {
  public record ProjectDto(int ProjectId, string ProjectName, string? Description, int ClientId, string? ClientName, DateOnly StartDate, DateOnly? EndDate, string Status);
}