using LinqToDB;
using LinqToDB.Data;
using dotnetProject.Models;
using dotnetProject.Dto;

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

    public async Task<IEnumerable<FilialDTO>> GetFiliaisComEmpresa()
    {
        var query = from f in _conexao.GetTable<FilialModel>()
                    join e in _conexao.GetTable<EmpresaModel>()
                        on f.EmpresaId equals e.Id into fe
                    from e in fe.DefaultIfEmpty()
                    select new FilialDTO
                    {
                        Id = f.Id,
                        Ativo = f.Ativo,
                        Nome = f.Nome,
                        Cnpj = f.Cnpj,
                        Cep = f.Cep,
                        Endereco = f.Endereco,
                        Numero = f.Numero,
                        Rua = f.Rua,
                        Cidade = f.Cidade,
                        Estado = f.Estado,
                        Bairro = f.Bairro,
                        Complemento = f.Complemento,
                        Telefone = f.Telefone,
                        Celular = f.Celular,
                        Email = f.Email,
                        DataAbertura = f.DataAbertura,
                        Cor = f.Cor,
                        NumeroInscricaoEstadual = f.NumeroInscricaoEstadual,
                        NumeroInscricaoMunicipal = f.NumeroInscricaoMunicipal,
                        NumeroAlvara = f.NumeroAlvara,
                        Observacoes = f.Observacoes,
                        EmpresaId = f.EmpresaId,
                        CreatedAt = f.CreatedAt,
                        UpdatedAt = f.UpdatedAt,
                        Empresa = e
                    };

        return await query.ToListAsync();
    }
}