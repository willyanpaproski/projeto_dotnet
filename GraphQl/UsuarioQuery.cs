using dotnetProject.Dto;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class UsuarioQuery
{
    public async Task<IEnumerable<UsuarioDTO>> PegarUsuarios(
        [Service] IUsuario usuarioService,
        long? id = null,
        FiltroOperador? idOperador = null,
        bool? ativo = null,
        FiltroOperador? ativoOperador = null,
        string? email = null,
        FiltroOperador? emailOperador = null,
        string? nomeUsuario = null,
        FiltroOperador? nomeUsuarioOperador = null,
        string? lastLoggedIn = null,
        FiltroOperador? lastLoggedInOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null,
        string? updatedAt = null,
        FiltroOperador? updatedAtOperador = null
    )
    {
        try
        {
            var usuarios = await usuarioService.ListarTodos();

            usuarios = usuarios
            .FiltrarLong(id, idOperador, u => u.Id)
            .FiltrarBool(ativo, ativoOperador, u => u.Ativo)
            .FiltrarString(email, emailOperador, u => u.Email)
            .FiltrarString(nomeUsuario, nomeUsuarioOperador, u => u.NomeUsuario)
            .FiltrarDateTime(lastLoggedIn, lastLoggedInOperador, u => u.LastLoggedIn)
            .FiltrarDateTime(createdAt, createdAtOperador, u => u.CreatedAt)
            .FiltrarDateTime(updatedAt, updatedAtOperador, u => u.UpdatedAt);

            return usuarios;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar usuários: ${ex.Message}");
        }
    }
}