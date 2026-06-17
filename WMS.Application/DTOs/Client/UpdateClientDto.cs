using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs.Client {
  public record UpdateClientDto {
    [Required][MaxLength(100)] public string ClientName { get; init; }
    [Required][MaxLength(100)] public string ContactPerson { get; init; }
    [Required][EmailAddress] public string Email { get; init; }
    public decimal? ClientPhoneNumber { get; init; }
    public string? Address { get; init; }
  }
}