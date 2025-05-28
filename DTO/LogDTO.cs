namespace dotnetProject.Dto;

public record LogDTO
{
    public long Id { get; set; }
    public string? Tabela { get; set; }
    public TipoLogEnum TipoLog { get; set; }
    public string? Usuario { get; set; }
    public string? Campos { get; set; }
    public DateTime CreatedAt { get; set; }
}