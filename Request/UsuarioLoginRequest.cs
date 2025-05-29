using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Request;

public class UsuarioLoginRequest
{
    [Required(ErrorMessage = "Email é obrigatório.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public string? Senha { get; set; }
}
