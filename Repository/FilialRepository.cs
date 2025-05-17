using LinqToDB;
using LinqToDB.Data;
using dotnetProject.Models;

public class FilialRepository
{
    protected readonly DataConnection _conexao;

    public FilialRepository(DataConnection conexao)
    {
        _conexao = conexao;
    }

    public async Task<IEnumerable<FilialModel>> GetFiliaisAtivasPorEmpresaId(long empresaId)
    {
        return await _conexao.GetTable<FilialModel>()
        .Where(f => f.EmpresaId == empresaId && f.Ativo)
        .ToListAsync();
    }

    public async Task<IEnumerable<FilialModel>> GetFiliaisInativasPorEmpresaId(long empresaId)
    {
        return await _conexao.GetTable<FilialModel>()
        .Where(f => f.EmpresaId == empresaId && !f.Ativo)
        .ToListAsync();
    }
}