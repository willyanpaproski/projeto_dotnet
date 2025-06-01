using System.ComponentModel.DataAnnotations;
using dotnetProject.Models;
using dotnetProject.Utils;

namespace dotnetProject.Request;

public class FilialRequest
{
    public long? Id { get; set; }

    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres!")]
    [UniqueValue<FilialModel>("Nome", "Id", ErrorMessage = "Este nome já está em uso.")]
    public string? Nome { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CNPJ deve ser preenchido!")]
    [StringCharacters(14, ErrorMessage = "CNPJ deve ter 14 dígitos!")]
    [UniqueValue<FilialModel>("Cnpj", "Id", ErrorMessage = "Este CNPJ já está em uso.")]
    public string? Cnpj { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CEP deve ser preenchido!")]
    [StringCharacters(8, ErrorMessage = "CEP deve ter 8 caracteres!")]
    public string? Cep { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Endereço deve ser preenchido!")]
    [StringLength(255, ErrorMessage = "Endereço deve ter no máximo 255 caracteres!")]
    public string? Endereco { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Número deve ser preenchido!")]
    [StringLength(5, ErrorMessage = "Número deve ter no máximo 5 caracteres!")]
    public string? Numero { get; set; }

    public string? Rua { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }

    [StringCharacters(11, ErrorMessage = "Telefone deve ter 11 dígitos!")]
    [UniqueValue<FilialModel>("Telefone", "Id", ErrorMessage = "Este número de telefone já está em uso.")]
    public string? Telefone { get; set; }

    [StringCharacters(11, ErrorMessage = "Celular deve ter 11 dígitos!")]
    [UniqueValue<FilialModel>("Celular", "Id", ErrorMessage = "Este número de celular já está em uso.")]
    public string? Celular { get; set; }

    [EmailOptional(ErrorMessage = "Email inválido!")]
    [UniqueValue<FilialModel>("Email", "Id", ErrorMessage = "Este email já está em uso.")]
    public string? Email { get; set; }
    public DateOnly? DataAbertura { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Cor deve ser preenchido!")]
    [UniqueValue<FilialModel>("Cor", "Id", ErrorMessage = "Esta cor já está em uso.")]
    public string? Cor { get; set; }

    public string? NumeroInscricaoEstadual { get; set; }
    public string? NumeroInscricaoMunicipal { get; set; }
    public string? NumeroAlvara { get; set; }
    public string? Observacoes { get; set; }
    public long? EmpresaId { get; set; }
}