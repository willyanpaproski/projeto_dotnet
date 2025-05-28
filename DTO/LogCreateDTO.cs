namespace dotnetProject.Dto;

public record LogCreateDTO
{
    public string? Tabela { get; set; }
    public TipoLogEnum TipoLog { get; set; }
    public string? Usuario { get; set; }
    public string? Campos { get; set; }
}