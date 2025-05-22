using dotnetProject.Dto;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "Filial")]
public class FilialModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("Ativo"), NotNull]
    public bool Ativo { get; set; }

    [Column("Nome"), NotNull]
    public string? Nome { get; set; }

    [Column("Cnpj"), NotNull]
    public string? Cnpj { get; set; }

    [Column("Cep"), NotNull]
    public string? Cep { get; set; }

    [Column("Endereco"), NotNull]
    public string? Endereco { get; set; }

    [Column("Numero"), NotNull]
    public string? Numero { get; set; }

    [Column("Rua")]
    public string? Rua { get; set; }

    [Column("Cidade")]
    public string? Cidade { get; set; }

    [Column("Estado")]
    public string? Estado { get; set; }

    [Column("Bairro")]
    public string? Bairro { get; set; }

    [Column("Complemento")]
    public string? Complemento { get; set; }

    [Column("Telefone")]
    public string? Telefone { get; set; }

    [Column("Celular")]
    public string? Celular { get; set; }

    [Column("Email")]
    public string? Email { get; set; }

    [Column("DataAbertura")]
    public DateOnly? DataAbertura { get; set; }

    [Column("Cor"), NotNull]
    public string? Cor { get; set; }

    [Column("NumeroInscricaoEstadual")]
    public string? NumeroInscricaoEstadual { get; set; }

    [Column("NumeroInscricaoMunicipal")]
    public string? NumeroInscricaoMunicipal { get; set; }

    [Column("NumeroAlvara")]
    public string? NumeroAlvara { get; set; }

    [Column("Observacoes")]
    public string? Observacoes { get; set; }

    [Column("EmpresaId"), NotNull]
    public long? EmpresaId { get; set; }

    //Chaves Estrangeiras
    [Association(ThisKey = nameof(EmpresaId), OtherKey = nameof(EmpresaModel.Id), CanBeNull = false)]
    public EmpresaModel? Empresa { get; set; }

    public void CriarModel(FilialCreateDTO dto)
    {
        Ativo = true;
        Nome = dto.Nome;
        Cnpj = dto.Cnpj;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Numero = dto.Numero;
        Rua = dto.Rua;
        Cidade = dto.Cidade;
        Estado = dto.Estado;
        Bairro = dto.Bairro;
        Complemento = dto.Complemento;
        Telefone = dto.Telefone;
        Celular = dto.Celular;
        Email = dto.Email;
        DataAbertura = dto.DataAbertura;
        Cor = dto.Cor;
        NumeroInscricaoEstadual = dto.NumeroInscricaoEstadual;
        NumeroInscricaoMunicipal = dto.NumeroInscricaoMunicipal;
        NumeroAlvara = dto.NumeroAlvara;
        Observacoes = dto.Observacoes;
        EmpresaId = dto.EmpresaId;
    }

    public void AtualizarModel(FilialDTO dto)
    {
        Ativo = dto.Ativo;
        Nome = dto.Nome;
        Cnpj = dto.Cnpj;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Numero = dto.Numero;
        Rua = dto.Rua;
        Cidade = dto.Cidade;
        Estado = dto.Estado;
        Bairro = dto.Bairro;
        Complemento = dto.Complemento;
        Telefone = dto.Telefone;
        Celular = dto.Celular;
        Email = dto.Email;
        DataAbertura = dto.DataAbertura;
        Cor = dto.Cor;
        NumeroInscricaoEstadual = dto.NumeroInscricaoEstadual;
        NumeroInscricaoMunicipal = dto.NumeroInscricaoMunicipal;
        NumeroAlvara = dto.NumeroAlvara;
        Observacoes = dto.Observacoes;
        EmpresaId = dto.EmpresaId;
    }
}

