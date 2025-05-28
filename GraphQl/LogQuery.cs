using dotnetProject.Dto;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class LogQuery
{
    public async Task<IEnumerable<LogDTO>> PegarLogs(
        [Service] ILog logService,
        long? id = null,
        FiltroOperador? idOperador = null,
        string? tabela = null,
        FiltroOperador? tabelaOperador = null,
        TipoLogEnum? tipoLog = null,
        FiltroOperador? tipoLogOperador = null,
        string? usuario = null,
        FiltroOperador? usuarioOperador = null,
        string? campos = null,
        FiltroOperador? camposOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null
    )
    {
        try
        {
            var logs = await logService.ListarTodos();

            logs = logs
            .FiltrarLong(id, idOperador, l => l.Id)
            .FiltrarString(tabela, tabelaOperador, l => l.Tabela)
            .FiltrarEnum(tipoLog, tipoLogOperador, l => l.TipoLog)
            .FiltrarString(campos, camposOperador, l => l.Campos)
            .FiltrarDateTime(createdAt, createdAtOperador, l => l.CreatedAt);

            return logs;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar logs: ${ex.Message}");
        }        
    }
}