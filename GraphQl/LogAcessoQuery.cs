using dotnetProject.Dto;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class LogAcessoQuery
{
    public async Task<IEnumerable<LogAcessoDTO>> PegarTodosLogsAcesso(
        [Service] ILogAcesso logAcessoService,
        long? id = null,
        FiltroOperador? idOperador = null,
        TipoLogAcessoEnum? tipoLogAcesso = null,
        FiltroOperador? tipoLogAcessoOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null
    )
    {
        try
        {
            var logsAcesso = await logAcessoService.ListarTodos();

            logsAcesso = logsAcesso
            .FiltrarLong(id, idOperador, l => l.Id)
            .FiltrarEnum(tipoLogAcesso, tipoLogAcessoOperador, l => l.TipoLogAcesso)
            .FiltrarDateTime(createdAt, createdAtOperador, l => l.CreatedAt);

            return logsAcesso;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar logs de acesso: ${ex.Message}");
        }
    }

    public async Task<IEnumerable<LogAcessoDTO>> PegarTodosLogsAcessoComUsuario(
        [Service] ILogAcesso logAcessoService,
        long? id = null,
        FiltroOperador? idOperador = null,
        TipoLogAcessoEnum? tipoLogAcesso = null,
        FiltroOperador? tipoLogAcessoOperador = null,
        string? nomeUsuario = null,
        FiltroOperador? nomeUsuarioOperador = null,
        string? emailUsuario = null,
        FiltroOperador? emailUsuarioOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null
    )
    {
        try
        {
            var logsAcessoComUsuario = await logAcessoService.ListarLogsAcessoComUsuario();

            logsAcessoComUsuario = logsAcessoComUsuario
            .FiltrarLong(id, idOperador, l => l.Id)
            .FiltrarEnum(tipoLogAcesso, tipoLogAcessoOperador, l => l.TipoLogAcesso)
            .FiltrarString(nomeUsuario, nomeUsuarioOperador, l => l.Usuario.NomeUsuario)
            .FiltrarString(emailUsuario, emailUsuarioOperador, l => l.Usuario.Email)
            .FiltrarDateTime(createdAt, createdAtOperador, l => l.CreatedAt);

            return logsAcessoComUsuario;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar logs de acesso: ${ex.Message}");
        }
    }
}