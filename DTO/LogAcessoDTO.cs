using dotnetProject.Models;

namespace dotnetProject.Dto;

public record LogAcessoDTO
{
    public long Id { get; set; }
    public TipoLogAcessoEnum TipoLogAcesso { get; set; }
    public long? UsuarioId { get; set; }
    public DateTime CreatedAt { get; set; }
    public UsuarioModel? Usuario { get; set; }
}