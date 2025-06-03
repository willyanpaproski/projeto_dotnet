using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository;
using LinqToDB.Data;

namespace dotnetProject.Services;

public class LogService : ILog
{
    private readonly RepositorioGenerico<LogModel> _repositorio;

    public LogService(DataConnection conexao)
    {
        _repositorio = new RepositorioGenerico<LogModel>(conexao);
    }

    public async Task<IEnumerable<LogDTO>> ListarTodos()
    {
        var logs = await _repositorio.Get();

        return logs.OrderByDescending(l => l.Id).Select(l => new LogDTO
        {
            Id = l.Id,
            Tabela = l.Tabela ?? "",
            TipoLog = l.TipoLog,
            Usuario = l.Usuario ?? "",
            Campos = l.Campos ?? "",
            CreatedAt = l.CreatedAt
        });
    }

    public async Task<LogDTO?> ObterPorId(long Id)
    {
        var log = await _repositorio.GetById(Id);

        return new LogDTO
        {
            Id = log.Id,
            Tabela = log.Tabela ?? "",
            TipoLog = log.TipoLog,
            Usuario = log.Usuario ?? "",
            Campos = log.Campos ?? "",
            CreatedAt = log.CreatedAt
        };
    }

    public async Task<LogDTO> Criar(LogCreateDTO dto)
    {
        var log = new LogModel();
        log.CriarModel(dto);

        var logCriado = await _repositorio.CreateAsync(log);

        return new LogDTO
        {
            Id = logCriado.Id,
            Tabela = logCriado.Tabela ?? "",
            TipoLog = logCriado.TipoLog,
            Usuario = logCriado.Usuario ?? "",
            Campos = logCriado.Campos ?? ""
        };
    }
}