using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Attributes {
  public class MinimumAge : ValidationAttribute {
    private readonly int _minimumAge;

    public MinimumAge(int minimumAge) {
      _minimumAge = minimumAge;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
      if (value is DateOnly dateOfBirth) {
        if (dateOfBirth.AddYears(_minimumAge) <= DateOnly.FromDateTime(DateTime.Now)) {
          return ValidationResult.Success;
        }
        return new ValidationResult($"You must be atleast {_minimumAge} years old");
      }
      return new ValidationResult("Invalid date format");
    }
  }
}