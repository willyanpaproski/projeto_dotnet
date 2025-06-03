using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository;
using LinqToDB.Data;

namespace dotnetProject.Services;

public class LogAcessoService : ILogAcesso
{
    public readonly RepositorioGenerico<LogAcessoModel> _repositorio;
    private readonly LogAcessoRepository _logAcessoRepository;

    public LogAcessoService(DataConnection conexao, LogAcessoRepository logAcessoRepository)
    {
        _repositorio = new RepositorioGenerico<LogAcessoModel>(conexao);
        _logAcessoRepository = logAcessoRepository;
    }

    public async Task<IEnumerable<LogAcessoDTO>> ListarTodos()
    {
        var logsAcesso = await _repositorio.Get();

        return logsAcesso.OrderByDescending(l => l.Id).Select(l => new LogAcessoDTO
        {
            Id = l.Id,
            TipoLogAcesso = l.TipoLogAcesso,
            UsuarioId = l.UsuarioId,
            CreatedAt = l.CreatedAt
        });
    }

    public async Task<LogAcessoDTO?> ObterPorId(long Id)
    {
        var logAcesso = await _repositorio.GetById(Id);

        return new LogAcessoDTO
        {
            Id = logAcesso.Id,
            TipoLogAcesso = logAcesso.TipoLogAcesso,
            UsuarioId = logAcesso.UsuarioId,
            CreatedAt = logAcesso.CreatedAt
        };
    }

    public async Task<LogAcessoDTO> Criar(LogAcessoCreateDTO dto)
    {
        var logAcesso = new LogAcessoModel();
        logAcesso.CriarModel(dto);

        var logAcessoCriado = await _repositorio.CreateAsync(logAcesso);

        return new LogAcessoDTO
        {
            Id = logAcessoCriado.Id,
            TipoLogAcesso = logAcessoCriado.TipoLogAcesso,
            UsuarioId = logAcessoCriado.UsuarioId,
            CreatedAt = logAcessoCriado.CreatedAt
        };
    }

    public async Task<IEnumerable<LogAcessoDTO>> ListarLogsAcessoComUsuario()
    {
        var logsAcessoComUsuario = await _logAcessoRepository.GetLogsAcessoComUsuario();

        return logsAcessoComUsuario.OrderByDescending(l => l.Id);
    }

    public async Task<LogAcessoDTO?> ObterLogAcessoComUsuarioById(long Id)
    {
        var logAcessoComUsuario = await _logAcessoRepository.GetLogAcessoComUsuarioById(Id);

        return logAcessoComUsuario;
    }
}