using System.ComponentModel.DataAnnotations;
using dotnetProject.Enums.TipoPessoaEnum;

namespace dotnetProject.Request;

public class ClienteRequest
{
    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "CPF/CNPJ deve ser preenchido!")]
    [StringLength(14, ErrorMessage = "CPF/CNPJ deve ter no máximo 14 caracteres!")]
    public string? CpfCnpj { get; set; }

    public DateOnly? DataNascimento { get; set; }

    [Required(ErrorMessage = "Tipo de pessoa deve ser informado.")]
    public TipoPessoaEnum TipoPessoa { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string? Email { get; set; }

    [StringLength(11, ErrorMessage = "Telefone deve ter no máximo 11 caracteres!")]
    public string? Telefone { get; set; }

    [StringLength(11, ErrorMessage = "Celular deve ter no máximo 11 caracteres!")]
    public string? Celular { get; set; }

    [Required(ErrorMessage = "CEP é obrigatório.")]
    [StringLength(8, ErrorMessage = "CEP deve ter no máximo 8 caracteres!")]
    public string? Cep { get; set; }

    [Required(ErrorMessage = "Endereço é obrigatório.")]
    public string? Endereco { get; set; }

    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Estado { get; set; }
    public string? Rua { get; set; }
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "Empresa é obrigatório.")]
    public long EmpresaId { get; set; }

    [Required(ErrorMessage = "Filial é obrigatório.")]
    public long? FilialId { get; set; }
}
