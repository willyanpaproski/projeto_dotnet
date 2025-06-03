using dotnetProject.Dto;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "LogAcesso")]
public class LogAcessoModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("TipoLog"), NotNull]
    public TipoLogAcessoEnum TipoLogAcesso { get; set; }

    [Column("UsuarioId"), NotNull]
    public long? UsuarioId { get; set; }

    //Chaves estrangeiras
    [Association(ThisKey = nameof(UsuarioId), OtherKey = nameof(UsuarioModel.Id), CanBeNull = false)]
    public UsuarioModel? Usuario { get; set; }

    public void CriarModel(LogAcessoCreateDTO dto)
    {
        TipoLogAcesso = dto.TipoLogAcesso;
        UsuarioId = dto.UsuarioId;
    }
}