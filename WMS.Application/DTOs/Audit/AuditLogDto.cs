namespace WMS.Application.DTOs.AuditLog {
  public record AuditLogDto(int AuditId, string EntityName, int RecordId, string Action, int CreatedBy, string? CreatorName, DateTime CreatedOn);
}