using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository;
using LinqToDB.Data;

namespace dotnetProject.Services;

public class FilialService : IFilial
{
    private readonly RepositorioGenerico<FilialModel> _repositorio;
    private readonly RepositorioGenerico<ClienteModel> _repositorioGenericoCliente;
    private readonly FilialRepository _filialRepository;
    private readonly ClienteRepository _clienteRepository;
    public LogService _logService;

    public FilialService(
        DataConnection conexao,
        ClienteRepository clienteRepository,
        FilialRepository filialRepository,
        LogService logService
    )
    {
        _repositorio = new RepositorioGenerico<FilialModel>(conexao);
        _repositorioGenericoCliente = new RepositorioGenerico<ClienteModel>(conexao);
        _clienteRepository = clienteRepository;
        _filialRepository = filialRepository;
        _logService = logService;
    }

    public async Task<IEnumerable<FilialDTO>> ListarTodos()
    {
        var filiais = await _repositorio.Get();

        return filiais.OrderByDescending(f => f.Id).Select(f => new FilialDTO
        {
            Id = f.Id,
            Ativo = f.Ativo,
            Nome = f.Nome ?? "",
            Cnpj = f.Cnpj ?? "",
            Cep = f.Cep ?? "",
            Endereco = f.Endereco ?? "",
            Numero = f.Numero ?? "",
            Rua = f.Rua ?? "",
            Cidade = f.Cidade ?? "",
            Estado = f.Estado ?? "",
            Bairro = f.Bairro ?? "",
            Complemento = f.Complemento ?? "",
            Telefone = f.Telefone ?? "",
            Celular = f.Celular ?? "",
            Email = f.Email ?? "",
            DataAbertura = f.DataAbertura,
            Cor = f.Cor ?? "",
            NumeroInscricaoEstadual = f.NumeroInscricaoEstadual ?? "",
            NumeroInscricaoMunicipal = f.NumeroInscricaoMunicipal ?? "",
            NumeroAlvara = f.NumeroAlvara ?? "",
            Observacoes = f.Observacoes ?? "",
            EmpresaId = f.EmpresaId,
            CreatedAt = f.CreatedAt,
            UpdatedAt = f.UpdatedAt
        });
    }

    public async Task<FilialDTO?> ObterPorId(long Id)
    {
        var filial = await _repositorio.GetById(Id);

        if (filial == null)
        {
            return null;
        }

        return new FilialDTO
        {
            Id = filial.Id,
            Ativo = filial.Ativo,
            Nome = filial.Nome ?? "",
            Cnpj = filial.Cnpj ?? "",
            Cep = filial.Cep ?? "",
            Endereco = filial.Endereco ?? "",
            Numero = filial.Numero ?? "",
            Rua = filial.Rua ?? "",
            Cidade = filial.Cidade ?? "",
            Estado = filial.Estado ?? "",
            Bairro = filial.Bairro ?? "",
            Complemento = filial.Complemento ?? "",
            Telefone = filial.Telefone ?? "",
            Celular = filial.Celular ?? "",
            Email = filial.Email ?? "",
            DataAbertura = filial.DataAbertura,
            Cor = filial.Cor ?? "",
            NumeroInscricaoEstadual = filial.NumeroInscricaoEstadual ?? "",
            NumeroInscricaoMunicipal = filial.NumeroInscricaoMunicipal ?? "",
            NumeroAlvara = filial.NumeroAlvara ?? "",
            Observacoes = filial.Observacoes ?? "",
            EmpresaId = filial.EmpresaId,
            CreatedAt = filial.CreatedAt,
            UpdatedAt = filial.UpdatedAt
        };
    }

    public async Task<FilialDTO> Criar(FilialCreateDTO dto)
    {
        var filial = new FilialModel();
        filial.CriarModel(dto);

        var filialCriada = await _repositorio.CreateAsync(filial);

        var retornoDto = new FilialDTO
        {
            Id = filialCriada.Id,
            Ativo = filialCriada.Ativo,
            Nome = filialCriada.Nome ?? "",
            Cnpj = filialCriada.Cnpj ?? "",
            Cep = filialCriada.Cep ?? "",
            Endereco = filialCriada.Endereco ?? "",
            Numero = filialCriada.Numero ?? "",
            Rua = filialCriada.Rua ?? "",
            Cidade = filialCriada.Cidade ?? "",
            Estado = filialCriada.Estado ?? "",
            Bairro = filialCriada.Bairro ?? "",
            Complemento = filialCriada.Complemento ?? "",
            Telefone = filialCriada.Telefone ?? "",
            Celular = filialCriada.Celular ?? "",
            Email = filialCriada.Email ?? "",
            DataAbertura = filialCriada.DataAbertura,
            Cor = filialCriada.Cor ?? "",
            NumeroInscricaoEstadual = filialCriada.NumeroInscricaoEstadual ?? "",
            NumeroInscricaoMunicipal = filialCriada.NumeroInscricaoMunicipal ?? "",
            NumeroAlvara = filialCriada.NumeroAlvara ?? "",
            Observacoes = filialCriada.Observacoes ?? "",
            EmpresaId = filialCriada.EmpresaId,
            CreatedAt = filialCriada.CreatedAt,
            UpdatedAt = filialCriada.UpdatedAt
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Filial",
            TipoLog = TipoLogEnum.Cadastro,
            Usuario = "teste",
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task<FilialDTO?> Atualizar(long Id, FilialDTO dto)
    {
        var filial = await _repositorio.GetById(Id);

        if (filial == null)
        {
            return null;
        }

        filial.AtualizarModel(dto);

        await _repositorio.UpdateAsync(filial);

        var filialAtualizada = await _repositorio.GetById(Id);

        if (filialAtualizada == null)
        {
            return null;
        }

        var retornoDto = new FilialDTO
        {
            Id = filialAtualizada.Id,
            Ativo = filialAtualizada.Ativo,
            Nome = filialAtualizada.Nome ?? "",
            Cnpj = filialAtualizada.Cnpj ?? "",
            Cep = filialAtualizada.Cep ?? "",
            Endereco = filialAtualizada.Endereco ?? "",
            Numero = filialAtualizada.Numero ?? "",
            Rua = filialAtualizada.Rua ?? "",
            Cidade = filialAtualizada.Cidade ?? "",
            Estado = filialAtualizada.Estado ?? "",
            Bairro = filialAtualizada.Bairro ?? "",
            Complemento = filialAtualizada.Complemento ?? "",
            Telefone = filialAtualizada.Telefone ?? "",
            Celular = filialAtualizada.Celular ?? "",
            Email = filialAtualizada.Email ?? "",
            DataAbertura = filialAtualizada.DataAbertura,
            Cor = filialAtualizada.Cor ?? "",
            NumeroInscricaoEstadual = filialAtualizada.NumeroInscricaoEstadual ?? "",
            NumeroInscricaoMunicipal = filialAtualizada.NumeroInscricaoMunicipal ?? "",
            NumeroAlvara = filialAtualizada.NumeroAlvara ?? "",
            Observacoes = filialAtualizada.Observacoes ?? "",
            EmpresaId = filialAtualizada.EmpresaId,
            CreatedAt = filialAtualizada.CreatedAt,
            UpdatedAt = filialAtualizada.UpdatedAt
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Filial",
            TipoLog = TipoLogEnum.Atualizacao,
            Usuario = "teste",
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task Remover(long Id)
    {
        var filialRemover = await _repositorio.GetById(Id);

        if (filialRemover == null)
        {
            return;
        }

        var dto = new FilialDTO
        {
            Id = filialRemover.Id,
            Ativo = filialRemover.Ativo,
            Nome = filialRemover.Nome ?? "",
            Cnpj = filialRemover.Cnpj ?? "",
            Cep = filialRemover.Cep ?? "",
            Endereco = filialRemover.Endereco ?? "",
            Numero = filialRemover.Numero ?? "",
            Rua = filialRemover.Rua ?? "",
            Cidade = filialRemover.Cidade ?? "",
            Estado = filialRemover.Estado ?? "",
            Bairro = filialRemover.Bairro ?? "",
            Complemento = filialRemover.Complemento ?? "",
            Telefone = filialRemover.Telefone ?? "",
            Celular = filialRemover.Celular ?? "",
            Email = filialRemover.Email ?? "",
            DataAbertura = filialRemover.DataAbertura,
            Cor = filialRemover.Cor ?? "",
            NumeroInscricaoEstadual = filialRemover.NumeroInscricaoEstadual ?? "",
            NumeroInscricaoMunicipal = filialRemover.NumeroInscricaoMunicipal ?? "",
            NumeroAlvara = filialRemover.NumeroAlvara ?? "",
            Observacoes = filialRemover.Observacoes ?? "",
            EmpresaId = filialRemover.EmpresaId,
            CreatedAt = filialRemover.CreatedAt,
            UpdatedAt = filialRemover.UpdatedAt
        };

        var clientesAtivosVinculados = await _clienteRepository.GetClientesAtivosPorFilialId(Id);

        if (clientesAtivosVinculados.Any())
        {
            throw new InvalidOperationException("Não é possível deletar uma filial com clientes ativos vinculados");
        }

        var clientesInativosVinculados = await _clienteRepository.GetClientesInativosPorFilialId(Id);

        if (clientesInativosVinculados.Any())
        {
            foreach (var cliente in clientesInativosVinculados)
            {
                cliente.FilialId = null;
                await _repositorioGenericoCliente.UpdateAsync(cliente);
            }
        }

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Filial",
            TipoLog = TipoLogEnum.Deletou,
            Usuario = "teste",
            Campos = dto.ToString()
        });

        await _repositorio.DeleteAsync(filialRemover);
    }

    public async Task<IEnumerable<FilialDTO>> GetFiliaisComEmpresa()
    {
        var filiais = await _filialRepository.GetFiliaisComEmpresa();

        return filiais.OrderByDescending(f => f.Id);
    }
}