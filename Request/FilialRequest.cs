using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Request;

public class FilialRequest
{
    [Required(ErrorMessage = "Ativo deve ser marcado!")]
    public bool Ativo { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Nome deve ser preenchido!")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres!")]
    public string Nome { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CNPJ deve ser preenchido!")]
    [StringLength(14, ErrorMessage = "CNPJ deve ter no máximo 14 caracteres!")]
    public string Cnpj { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CEP deve ser preenchido!")]
    [StringLength(8, ErrorMessage = "CEP deve ter no máximo 8 caracteres")]
    public string Cep { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Endereço deve ser preenchido!")]
    [StringLength(255, ErrorMessage = "Endereço deve ter no máximo 255 caracteres!")]
    public string Endereco { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Número deve ser preenchido!")]
    [StringLength(5, ErrorMessage = "Número deve ter no máximo 5 caracteres!")]
    public string Numero { get; set; }

    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Bairro { get; set; }
    public string Complemento { get; set; }
    public string Telefone { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public DateOnly DataAbertura { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Cor deve ser preenchido!")]
    public string Cor { get; set; }

    public string NumeroInscricaoEstadual { get; set; }
    public string NumeroInscricaoMunicipal { get; set; }
    public string NumeroAlvara { get; set; }
    public string Observacoes { get; set; }
    public long EmpresaId { get; set; }
}