using dotnetProject.Dto;

namespace dotnetProject.Interfaces;

public interface ILog
{
    Task<IEnumerable<LogDTO>> ListarTodos();
    Task<LogDTO?> ObterPorId(long Id);
    Task<LogDTO> Criar(LogCreateDTO dto);
}