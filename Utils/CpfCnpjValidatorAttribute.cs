using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Utils;

public class CpfCnpjValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string valor)
        {
            if (!string.IsNullOrWhiteSpace(valor))
            {
                if (valor.Length != 11 && valor.Length != 14)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
        return ValidationResult.Success;
    }
}