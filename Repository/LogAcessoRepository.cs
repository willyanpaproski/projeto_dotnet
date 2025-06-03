using LinqToDB;
using LinqToDB.Data;
using dotnetProject.Models;
using dotnetProject.Dto;

public class LogAcessoRepository
{
    protected readonly DataConnection _conexao;

    public LogAcessoRepository(DataConnection conexao)
    {
        _conexao = conexao;
    }

    public async Task<IEnumerable<LogAcessoDTO>> GetLogsAcessoComUsuario()
    {
        var query = from l in _conexao.GetTable<LogAcessoModel>()
                    join u in _conexao.GetTable<UsuarioModel>()
                        on l.UsuarioId equals u.Id into lu
                    from u in lu.DefaultIfEmpty()
                    select new LogAcessoDTO
                    {
                        Id = l.Id,
                        TipoLogAcesso = l.TipoLogAcesso,
                        UsuarioId = u.Id,
                        CreatedAt = l.CreatedAt,
                        Usuario = u
                    };

        return await query.ToListAsync();
    }

    public async Task<LogAcessoDTO?> GetLogAcessoComUsuarioById(long Id)
    {
        var query = from l in _conexao.GetTable<LogAcessoModel>()
                    join u in _conexao.GetTable<UsuarioModel>()
                        on l.UsuarioId equals u.Id into lu
                    from u in lu.DefaultIfEmpty()
                    where l.Id == Id
                    select new LogAcessoDTO
                    {
                        Id = l.Id,
                        TipoLogAcesso = l.TipoLogAcesso,
                        UsuarioId = l.UsuarioId,
                        CreatedAt = l.CreatedAt,
                        Usuario = u
                    };

        return await query.FirstOrDefaultAsync();
    }
}