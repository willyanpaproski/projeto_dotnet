namespace dotnetProject.Dto;

public record EmpresaCreateDTO
{
    public bool Ativo { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public DateOnly? DataFundacao { get; set; }
    public string? Cnpj { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Rua { get; set; }
    public string? Complemento { get; set; }
    public string? Site { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Cor { get; set; }
    public string? Observacoes { get; set; }
}