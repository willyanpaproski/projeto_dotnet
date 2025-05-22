using dotnetProject.Dto;
using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table(Name = "Empresa")]
public class EmpresaModel : EntidadeBase
{
    [Column("Id"), PrimaryKey, Identity]
    public long Id { get; set; }

    [Column("Ativo"), NotNull]
    public bool Ativo { get; set; }

    [Column("RazaoSocial"), NotNull]
    public string? RazaoSocial { get; set; }

    [Column("NomeFantasia"), NotNull]
    public string? NomeFantasia { get; set; }

    [Column("DataFundacao")]
    public DateOnly? DataFundacao { get; set; }

    [Column("Cnpj"), NotNull]
    public string? Cnpj { get; set; }

    [Column("Cep"), NotNull]
    public string? Cep { get; set; }

    [Column("Endereco"), NotNull]
    public string? Endereco { get; set; }

    [Column("Numero"), NotNull]
    public string? Numero { get; set; }

    [Column("Cidade")]
    public string? Cidade { get; set; }

    [Column("Bairro")]
    public string? Bairro { get; set; }

    [Column("Rua")]
    public string? Rua { get; set; }

    [Column("Complemento")]
    public string? Complemento { get; set; }

    [Column("Site")]
    public string? Site { get; set; }

    [Column("Email")]
    public string? Email { get; set; }

    [Column("Telefone")]
    public string? Telefone { get; set; }

    [Column("Cor"), NotNull]
    public string? Cor { get; set; }

    [Column("Observacoes")]
    public string? Observacoes { get; set; }

    public void CriarModel(EmpresaCreateDTO dto) 
    {
        Ativo = true;
        RazaoSocial = dto.RazaoSocial;
        NomeFantasia = dto.NomeFantasia;
        DataFundacao = dto.DataFundacao;
        Cnpj = dto.Cnpj;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Numero = dto.Numero;
        Cidade = dto.Cidade;
        Bairro = dto.Bairro;
        Rua = dto.Rua;
        Complemento = dto.Complemento;
        Site = dto.Site;
        Email = dto.Email;
        Telefone = dto.Telefone;
        Cor = dto.Cor;
        Observacoes = dto.Observacoes;
    }

    public void AtualizarModel(EmpresaDTO dto)
    {
        Ativo = dto.Ativo;
        RazaoSocial = dto.RazaoSocial;
        NomeFantasia = dto.NomeFantasia;
        DataFundacao = dto.DataFundacao;
        Cnpj = dto.Cnpj;
        Cep = dto.Cep;
        Endereco = dto.Endereco;
        Numero = dto.Numero;
        Cidade = dto.Cidade;
        Bairro = dto.Bairro;
        Rua = dto.Rua;
        Complemento = dto.Complemento;
        Site = dto.Site;
        Email = dto.Email;
        Telefone = dto.Telefone;
        Cor = dto.Cor;
        Observacoes = dto.Observacoes;
    }
}