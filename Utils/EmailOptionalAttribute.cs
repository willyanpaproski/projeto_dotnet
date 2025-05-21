using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Utils;

public class EmailOptionalAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email && !string.IsNullOrWhiteSpace(email))
        {
            var emailAddressAttribute = new EmailAddressAttribute();
            if (!emailAddressAttribute.IsValid(email))
            {
                return new ValidationResult(ErrorMessage ?? "Email inválido!");
            }
        }
        return ValidationResult.Success;
    }
}