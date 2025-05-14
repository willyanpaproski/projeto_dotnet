using dotnetProject.Dto;

namespace dotnetProject.Interfaces;

public interface ICliente
{
    Task<IEnumerable<ClienteDTO>> ListarTodos();
    Task<ClienteDTO?> ObterPorId(long Id);
    Task<ClienteDTO> Criar(ClienteCreateDTO cliente);
    Task<ClienteDTO?> Atualizar(long Id, ClienteDTO cliente);
    Task Remover(long Id);
}