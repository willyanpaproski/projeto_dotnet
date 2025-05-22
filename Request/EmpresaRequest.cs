using System.ComponentModel.DataAnnotations;
using dotnetProject.Utils;

namespace dotnetProject.Request;

public class EmpresaRequest
{
    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Razão Social deve ser preenchido!")]
    [StringLength(200, ErrorMessage = "Razão Social deve ter no máximo 200 caracteres!")]
    public string? RazaoSocial { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome Fantasia deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome Fantasia deve conter no máximo 100 caracteres!")]
    public string? NomeFantasia { get; set; }

    public DateOnly? DataFundacao { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CNPJ deve ser preenchido!")]
    [StringCharacters(14, ErrorMessage = "CNPJ deve ter 14 dígitos!")]
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
    public string? Email { get; set; }

    [StringCharacters(11, ErrorMessage = "Telefone deve ter 11 caracteres!")]
    public string? Telefone { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Cor deve ser preenchido!")]
    public string? Cor { get; set; }
    public string? Observacoes { get; set; }
    
}