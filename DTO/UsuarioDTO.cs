namespace dotnetProject.Dto;

public record UsuarioDTO
{
    public long Id { get; set; }
    public bool Ativo { get; set; }
    public string? Email { get; set; }
    public string? SenhaHash { get; set; }
    public DateTime LastLoggedIn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}