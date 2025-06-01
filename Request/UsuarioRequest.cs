using System.ComponentModel.DataAnnotations;
using dotnetProject.Models;
using dotnetProject.Utils;

namespace dotnetProject.Request;

public class UsuarioRequest
{
    public long? Id { get; set; }

    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "Email deve ser preenchido!")]
    [EmailAddress(ErrorMessage = "Email inválido!")]
    [UniqueValue<UsuarioModel>("Email", "Id", ErrorMessage = "Este email já está em uso.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Nome de usuário deve ser preenchido!")]
    [UniqueValue<UsuarioModel>("NomeUsuario", "Id", ErrorMessage = "Este nome de usuário já está em uso.")]
    public string? NomeUsuario { get; set; }

    [Required(ErrorMessage = "Senha deve ser preenchida!")]
    public string? SenhaHash { get; set; }
    public DateTime? LastLoggedIn { get; set; }
}