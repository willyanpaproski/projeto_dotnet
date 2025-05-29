using dotnetProject.Dto;
using dotnetProject.Request;

namespace dotnetProject.Interfaces;

public interface IUsuario
{
    Task<IEnumerable<UsuarioDTO>> ListarTodos();
    Task<UsuarioDTO?> ObterPorId(long Id);
    Task<UsuarioDTO> Criar(UsuarioCreateDTO usuario);
    Task<UsuarioDTO?> Atualizar(long Id, UsuarioDTO usuario);
    Task Remover(long Id);
    Task<UsuarioDTO?> LoginAsync(UsuarioLoginRequest usuario);
}