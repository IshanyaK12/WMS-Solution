using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Employee {
  public record CreateEmployeeDto {
    [Required][MaxLength(50)] public string Firstname { get; init; }
    [Required][MaxLength(50)] public string Lastname { get; init; }
    [Required][EmailAddress] public string Email { get; init; }
    [Required] public string PhoneNumber { get; init; }
    [Required][RegularExpression("^[MFO]$", ErrorMessage = "The gender must be M, F or O")] public char Gender { get; init; }
    [Required] public DateOnly DOB { get; init; }
    [Required] public DateOnly DOJ { get; init; }
    [Required] public int DepartmentId { get; init; }
    [Required] public int RoleId { get; init; }
    [Required][MaxLength(20)] public string Status { get; init; }
  }
}