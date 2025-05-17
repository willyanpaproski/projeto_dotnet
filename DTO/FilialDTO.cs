namespace dotnetProject.Dto;

public record FilialDTO
{
    public long Id { get; set; }
    public bool Ativo { get; set; }
    public string? Nome { get; set; }
    public string? Cnpj { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Rua { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Email { get; set; }
    public DateOnly DataAbertura { get; set; }
    public string? Cor { get; set; }
    public string? NumeroInscricaoEstadual { get; set; }
    public string? NumeroInscricaoMunicipal { get; set; }
    public string? NumeroAlvara { get; set; }
    public string? Observacoes { get; set; }
    public long? EmpresaId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}