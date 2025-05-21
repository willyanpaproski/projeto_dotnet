using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Utils;

public class StringCharactersAttribute : ValidationAttribute
{
    private readonly int _requiredLength;

    public StringCharactersAttribute(int requiredLength)
    {
        _requiredLength = requiredLength;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string valor)
        {
            if (!string.IsNullOrWhiteSpace(valor))
            {
                if (valor.Length != _requiredLength)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
        return ValidationResult.Success;
    }
}
