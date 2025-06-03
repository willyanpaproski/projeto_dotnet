using dotnetProject.Dto;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "Log")]
public class LogModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("Tabela"), NotNull]
    public string? Tabela { get; set; }

    [Column("TipoLog"), NotNull]
    public TipoLogEnum TipoLog { get; set; }

    [Column("Usuario")]
    public string? Usuario { get; set; }

    [Column("Campos")]
    public string? Campos { get; set; }

    public void CriarModel(LogCreateDTO dto)
    {
        Tabela = dto.Tabela;
        TipoLog = dto.TipoLog;
        Usuario = dto.Usuario;
        Campos = dto.Campos;
    }
}