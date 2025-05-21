using dotnetProject.Dto;
using dotnetProject.Enums;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "Cliente")]
public class ClienteModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("Ativo"), NotNull]
    public bool Ativo { get; set; }

    [Column("Nome"), NotNull]
    public string? Nome { get; set; }

    [Column("CpfCnpj"), NotNull]
    public string? CpfCnpj { get; set; }

    [Column("DataNascimento"), NotNull]
    public DateOnly DataNascimento { get; set; }

    [Column("TipoPessoa"), NotNull]
    public TipoPessoaEnum TipoPessoa { get; set; }

    [Column("Email")]
    public string? Email { get; set; }

    [Column("Telefone")]
    public string? Telefone { get; set; }

    [Column("Celular")]
    public string? Celular { get; set; }

    [Column("Cep"), NotNull]
    public string? Cep { get; set; }

    [Column("Endereco"), NotNull]
    public string? Endereco { get; set; }

    [Column("Cidade")]
    public string? Cidade { get; set; }

    [Column("Bairro")]
    public string? Bairro { get; set; }

    [Column("Estado")]
    public string? Estado { get; set; }

    [Column("Rua")]
    public string? Rua { get; set; }

    [Column("Complemento")]
    public string? Complemento { get; set; }
    
    [Column("EmpresaId"), NotNull]
    public long? EmpresaId { get; set; }

    [Column("FilialId"), NotNull]
    public long? FilialId { get; set; }

    //Chaves Estrangeiras
    [Association(ThisKey = nameof(EmpresaId), OtherKey = nameof(EmpresaModel.Id), CanBeNull = false)]
    public EmpresaModel? Empresa { get; set; }

    [Association(ThisKey = nameof(FilialId), OtherKey = nameof(FilialModel.Id), CanBeNull = false)]
    public FilialModel? Filial { get; set; }

    public void CriarModel(ClienteCreateDTO dto)
    {
        Ativo = true;
        Nome = dto.Nome;
        CpfCnpj = dto.CpfCnpj;
        DataNascimento = dto.DataNascimento;
        TipoPessoa = dto.TipoPessoa;
        Email = dto.Email;
        Telefone = dto.Telefone;
        Celular = dto.Celular;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Cidade = dto.Cidade;
        Bairro = dto.Bairro;
        Estado = dto.Estado;
        Rua = dto.Rua;
        Complemento = dto.Complemento;
        EmpresaId = dto.EmpresaId;
        FilialId = dto.FilialId;
    }

    public void AtualizarModel(ClienteDTO dto)
    {
        Ativo = dto.Ativo;
        Nome = dto.Nome;
        CpfCnpj = dto.CpfCnpj;
        DataNascimento = dto.DataNascimento;
        TipoPessoa = dto.TipoPessoa;
        Email = dto.Email;
        Telefone = dto.Telefone;
        Celular = dto.Celular;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Cidade = dto.Cidade;
        Bairro = dto.Bairro;
        Estado = dto.Estado;
        Rua = dto.Rua;
        Complemento = dto.Complemento;
        EmpresaId = dto.EmpresaId;
        FilialId = dto.FilialId;
    }
}