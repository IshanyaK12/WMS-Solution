namespace WMS.Application.DTOs.Client {
  public record ClientDto(int ClientId, string ClientName, string ContactPerson, string Email, decimal? ClientPhoneNumber, string? Address);
}