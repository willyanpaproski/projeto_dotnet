namespace dotnetProject.Dto;

public record UsuarioCreateDTO
{
    public bool Ativo { get; set; }
    public string? Email { get; set; }
    public string? SenhaHash { get; set; }
    public DateTime LastLoggedIn { get; set; }
}