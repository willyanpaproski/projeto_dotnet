using System.ComponentModel.DataAnnotations;
using dotnetProject.Models;
using dotnetProject.Utils;

namespace dotnetProject.Request;

public class EmpresaRequest
{
    public long? Id { get; set; }

    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Razão Social deve ser preenchido!")]
    [StringLength(200, ErrorMessage = "Razão Social deve ter no máximo 200 caracteres!")]
    [UniqueValue<EmpresaModel>("RazaoSocial", "Id", ErrorMessage = "Esta razão social já está em uso.")]
    public string? RazaoSocial { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome Fantasia deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome Fantasia deve conter no máximo 100 caracteres!")]
    [UniqueValue<EmpresaModel>("NomeFantasia", "Id", ErrorMessage = "Este nome fantasia já está em uso.")]
    public string? NomeFantasia { get; set; }

    public DateOnly? DataFundacao { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CNPJ deve ser preenchido!")]
    [StringCharacters(14, ErrorMessage = "CNPJ deve ter 14 dígitos!")]
    [UniqueValue<EmpresaModel>("Cnpj", "Id", ErrorMessage = "Este CNPJ já está em uso.")]
    public string? Cnpj { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CEP deve ser preenchido!")]
    [StringCharacters(8, ErrorMessage = "CEP deve ter 8 dígitos!")]
    public string? Cep { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Endereço deve ser preenchido!")]
    [StringLength(255, ErrorMessage = "Endereço deve conter no máximo 255 caracteres")]
    public string? Endereco { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Número deve ser preenchido!")]
    [StringLength(5, ErrorMessage = "Número deve conter no máximo 5 caracteres")]
    public string? Numero { get; set; }

    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Rua { get; set; }
    public string? Complemento { get; set; }
    public string? Site { get; set; }

    [EmailOptional(ErrorMessage = "Email inválido!")]
    [UniqueValue<EmpresaModel>("Email", "Id", ErrorMessage = "Este email já está em uso.")]
    public string? Email { get; set; }

    [StringCharacters(11, ErrorMessage = "Telefone deve ter 11 caracteres!")]
    [UniqueValue<EmpresaModel>("Telefone", "Id", ErrorMessage = "Este número de telefone já está em uso.")]
    public string? Telefone { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Cor deve ser preenchido!")]
    [UniqueValue<EmpresaModel>("Cor", "Id", ErrorMessage = "Esta cor já está em uso.")]
    public string? Cor { get; set; }
    public string? Observacoes { get; set; }
}