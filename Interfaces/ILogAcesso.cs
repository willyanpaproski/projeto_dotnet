using dotnetProject.Dto;

namespace dotnetProject.Interfaces;

public interface ILogAcesso
{
    Task<IEnumerable<LogAcessoDTO>> ListarTodos();
    Task<LogAcessoDTO?> ObterPorId(long Id);
    Task<LogAcessoDTO> Criar(LogAcessoCreateDTO dto);
    Task<IEnumerable<LogAcessoDTO>> ListarLogsAcessoComUsuario();
    Task<LogAcessoDTO?> ObterLogAcessoComUsuarioById(long Id);
}