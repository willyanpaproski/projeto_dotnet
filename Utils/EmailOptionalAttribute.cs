using System.ComponentModel.DataAnnotations;

public class EmailOptionalAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email && !string.IsNullOrWhiteSpace(email))
        {
            // Verifica se o e-mail é válido
            var emailAddressAttribute = new EmailAddressAttribute();
            if (!emailAddressAttribute.IsValid(email))
            {
                return new ValidationResult(ErrorMessage ?? "Email inválido.");
            }
        }
        // Se o valor for nulo ou uma string vazia, a validação é considerada válida
        return ValidationResult.Success;
    }
}