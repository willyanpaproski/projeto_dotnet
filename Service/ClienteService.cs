using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository;
using LinqToDB.Data;
using Microsoft.AspNetCore.Identity;

namespace dotnetProject.Services;

public class ClienteService : ICliente
{
    private readonly RepositorioGenerico<ClienteModel> _repositorio;
    public LogService _logService;

    public ClienteService(DataConnection conexao, LogService logService)
    {
        _repositorio = new RepositorioGenerico<ClienteModel>(conexao);
        _logService = logService;
    }

    public async Task<IEnumerable<ClienteDTO>> ListarTodos()
    {
        var clientes = await _repositorio.Get();

        return clientes.OrderByDescending(c => c.Id).Select(c => new ClienteDTO{
            Id = c.Id,
            Ativo = c.Ativo,
            Nome = c.Nome ?? "",
            CpfCnpj = c.CpfCnpj ?? "",
            DataNascimento = c.DataNascimento,
            TipoPessoa = c.TipoPessoa,
            Email = c.Email ?? "",
            Telefone = c.Telefone ?? "",
            Celular = c.Celular ?? "",
            Cep = c.Cep ?? "",
            Endereco = c.Endereco ?? "",
            Cidade = c.Cidade ?? "",
            Bairro = c.Bairro ?? "",
            Estado = c.Estado ?? "",
            Rua = c.Rua ?? "",
            Complemento = c.Complemento ?? "",
            EmpresaId = c.EmpresaId,
            FilialId = c.FilialId,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        });
    }

    public async Task<ClienteDTO?> ObterPorId(long Id)
    {
        var cliente = await _repositorio.GetById(Id);

        if (cliente == null) {
            return null;
        }

        return new ClienteDTO{
            Id = cliente.Id,
            Ativo = cliente.Ativo,
            Nome = cliente.Nome ?? "",
            CpfCnpj = cliente.CpfCnpj ?? "",
            DataNascimento = cliente.DataNascimento,
            TipoPessoa = cliente.TipoPessoa,
            Email = cliente.Email ?? "",
            Telefone = cliente.Telefone ?? "",
            Celular = cliente.Celular ?? "",
            Cep = cliente.Cep ?? "",
            Endereco = cliente.Endereco ?? "",
            Cidade = cliente.Cidade ?? "",
            Estado = cliente.Estado ?? "",
            Rua = cliente.Rua ?? "",
            Complemento = cliente.Complemento ?? "",
            EmpresaId = cliente.EmpresaId,
            FilialId = cliente.FilialId,
            CreatedAt = cliente.CreatedAt,
            UpdatedAt = cliente.UpdatedAt
        };
    }

    public async Task<ClienteDTO> Criar(ClienteCreateDTO dto)
    {
        
        var cliente = new ClienteModel();
        cliente.CriarModel(dto);

        var clienteCriado = await _repositorio.CreateAsync(cliente);
        
        var retornoDto = new ClienteDTO
        {
            Id = clienteCriado.Id,
            Ativo = clienteCriado.Ativo,
            Nome = clienteCriado.Nome ?? "",
            CpfCnpj = clienteCriado.CpfCnpj ?? "",
            DataNascimento = clienteCriado.DataNascimento,
            TipoPessoa = clienteCriado.TipoPessoa,
            Email = clienteCriado.Email ?? "",
            Telefone = clienteCriado.Telefone ?? "",
            Celular = clienteCriado.Celular ?? "",
            Cep = clienteCriado.Cep ?? "",
            Endereco = clienteCriado.Endereco ?? "",
            Cidade = clienteCriado.Cidade ?? "",
            Bairro = clienteCriado.Bairro ?? "",
            Estado = clienteCriado.Estado ?? "",
            Rua = clienteCriado.Rua ?? "",
            Complemento = clienteCriado.Complemento ?? "",
            EmpresaId = clienteCriado.EmpresaId,
            FilialId = clienteCriado.FilialId,
            CreatedAt = clienteCriado.CreatedAt,
            UpdatedAt = clienteCriado.UpdatedAt
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Cliente",
            TipoLog = TipoLogEnum.Cadastro,
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task<ClienteDTO?> Atualizar(long Id, ClienteDTO dto)
    {   
        var cliente = await _repositorio.GetById(Id);
        
        if (cliente == null) {
            return null;
        }

        cliente.AtualizarModel(dto);

        await _repositorio.UpdateAsync(cliente);

        var clienteAtualizado = await _repositorio.GetById(Id);

        if (clienteAtualizado == null)
        {
            return null;
        }

        var retornoDto = new ClienteDTO
        {
            Id = clienteAtualizado.Id,
            Ativo = clienteAtualizado.Ativo,
            Nome = clienteAtualizado.Nome ?? "",
            CpfCnpj = clienteAtualizado.CpfCnpj ?? "",
            DataNascimento = clienteAtualizado.DataNascimento,
            TipoPessoa = clienteAtualizado.TipoPessoa,
            Email = clienteAtualizado.Email ?? "",
            Telefone = clienteAtualizado.Telefone ?? "",
            Celular = clienteAtualizado.Celular ?? "",
            Cep = clienteAtualizado.Cep ?? "",
            Endereco = clienteAtualizado.Endereco ?? "",
            Cidade = clienteAtualizado.Cidade ?? "",
            Bairro = clienteAtualizado.Bairro ?? "",
            Estado = clienteAtualizado.Estado ?? "",
            Rua = clienteAtualizado.Rua ?? "",
            Complemento = clienteAtualizado.Complemento ?? "",
            EmpresaId = clienteAtualizado.EmpresaId,
            FilialId = clienteAtualizado.FilialId,
            CreatedAt = clienteAtualizado.CreatedAt,
            UpdatedAt = clienteAtualizado.UpdatedAt
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Cliente",
            TipoLog = TipoLogEnum.Atualizacao,
            Usuario = "Teste",
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task Remover(long Id)
    {
        var clienteRemover = await _repositorio.GetById(Id);

        if (clienteRemover == null) {
            return;
        }

        var dto = new ClienteDTO
        {
            Id = clienteRemover.Id,
            Ativo = clienteRemover.Ativo,
            Nome = clienteRemover.Nome ?? "",
            CpfCnpj = clienteRemover.CpfCnpj ?? "",
            DataNascimento = clienteRemover.DataNascimento,
            TipoPessoa = clienteRemover.TipoPessoa,
            Email = clienteRemover.Email ?? "",
            Telefone = clienteRemover.Telefone ?? "",
            Celular = clienteRemover.Celular ?? "",
            Cep = clienteRemover.Cep ?? "",
            Endereco = clienteRemover.Endereco ?? "",
            Cidade = clienteRemover.Cidade ?? "",
            Bairro = clienteRemover.Bairro ?? "",
            Estado = clienteRemover.Estado ?? "",
            Rua = clienteRemover.Rua ?? "",
            Complemento = clienteRemover.Complemento ?? "",
            EmpresaId = clienteRemover.EmpresaId,
            FilialId = clienteRemover.FilialId,
            CreatedAt = clienteRemover.CreatedAt,
            UpdatedAt = clienteRemover.UpdatedAt
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Cliente",
            TipoLog = TipoLogEnum.Deletou,
            Usuario = "Teste",
            Campos = dto.ToString()
        });

        await _repositorio.DeleteAsync(clienteRemover);
    }
}