using System.ComponentModel.DataAnnotations;
using dotnetProject.Enums;
using dotnetProject.Models;
using dotnetProject.Utils;

namespace dotnetProject.Request;

public class ClienteRequest
{
    public long? Id { get; set; }

    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres!")]
    [UniqueValue<ClienteModel>("Nome", "Id", ErrorMessage = "Este nome já está em uso.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "CPF/CNPJ deve ser preenchido!")]
    [CpfCnpjValidator(ErrorMessage = "CPF/CNPJ deve conter 11 ou 14 caracteres")]
    public string? CpfCnpj { get; set; }

    public DateOnly? DataNascimento { get; set; }

    [Required(ErrorMessage = "Tipo de pessoa deve ser informado!")]
    public TipoPessoaEnum TipoPessoa { get; set; }

    [EmailOptional(ErrorMessage = "Email inválido.")]
    [UniqueValue<ClienteModel>("Email", "Id", ErrorMessage = "Este email já está em uso.")]
    public string? Email { get; set; }

    [StringCharacters(11, ErrorMessage = "Telefone deve ter 11 dígitos!")]
    [UniqueValue<ClienteModel>("Telefone", "Id", ErrorMessage = "Este número de telefone já está em uso.")]
    public string? Telefone { get; set; }

    [StringCharacters(11, ErrorMessage = "Celular deve ter 11 dígitos!")]
    [UniqueValue<ClienteModel>("Celular", "Id", ErrorMessage = "Este número de celular já está em uso.")]
    public string? Celular { get; set; }

    [Required(ErrorMessage = "CEP deve ser preenchido!")]
    [StringCharacters(8, ErrorMessage = "CEP deve ter 8 caracteres!")]
    public string? Cep { get; set; }

    [Required(ErrorMessage = "Endereço deve ser preenchido!")]
    public string? Endereco { get; set; }

    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Estado { get; set; }
    public string? Rua { get; set; }
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "Empresa deve ser preenchido!")]
    public long? EmpresaId { get; set; }

    [Required(ErrorMessage = "Filial deve ser preenchido!")]
    public long? FilialId { get; set; }
}
