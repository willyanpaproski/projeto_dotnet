using dotnetProject.Models;

namespace dotnetProject.Dto;

public record LogAcessoCreateDTO
{
    public TipoLogAcessoEnum TipoLogAcesso { get; set; }
    public long? UsuarioId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UsuarioModel? Usuario { get; set; }
}