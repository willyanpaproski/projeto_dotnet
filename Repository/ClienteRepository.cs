using LinqToDB;
using LinqToDB.Data;
using dotnetProject.Models;

namespace dotnetProject.Repository;

public class ClienteRepository
{
    protected readonly DataConnection _conexao;

    public ClienteRepository(DataConnection conexao)
    {
        _conexao = conexao;
    }

    public async Task<IEnumerable<ClienteModel>> GetClientesAtivosPorFilialId(long filialId)
    {
        return await _conexao.GetTable<ClienteModel>()
        .Where(c => c.FilialId == filialId && c.Ativo)
        .ToListAsync();
    }

    public async Task<IEnumerable<ClienteModel>> GetClientesInativosPorFilialId(long filialId)
    {
        return await _conexao.GetTable<ClienteModel>()
        .Where(c => c.FilialId == filialId && !c.Ativo)
        .ToListAsync();
    }
}