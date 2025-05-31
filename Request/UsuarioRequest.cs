using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Request;

public class UsuarioRequest
{
    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "Email deve ser preenchido!")]
    [EmailAddress(ErrorMessage = "Email inválido!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Nome de usuário deve ser preenchido!")]
    public string? NomeUsuario { get; set; }

    [Required(ErrorMessage = "Senha deve ser preenchida!")]
    public string? SenhaHash { get; set; }
    public DateTime LastLoggedIn { get; set; }
}