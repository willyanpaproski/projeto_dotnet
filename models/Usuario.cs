using dotnetProject.Dto;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "Usuario")]
public class UsuarioModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("Ativo"), NotNull]
    public bool Ativo { get; set; }

    [Column("Email"), NotNull]
    public string? Email { get; set; }

    [Column("SenhaHash"), NotNull]
    public string? SenhaHash { get; set; }

    [Column("LastLoggedIn")]
    public DateTime LastLoggedIn { get; set; }

    public void CriarModel(UsuarioCreateDTO dto)
    {
        Ativo = dto.Ativo;
        Email = dto.Email;
        SenhaHash = dto.SenhaHash;
        LastLoggedIn = dto.LastLoggedIn;
    }

    public void AtualizarModel(UsuarioDTO dto)
    {
        Id = dto.Id;
        Ativo = dto.Ativo;
        Email = dto.Email;
        SenhaHash = dto.SenhaHash;
        LastLoggedIn = dto.LastLoggedIn;
    }
}