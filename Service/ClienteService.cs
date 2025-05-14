using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository.RepositorioGenerico;
using LinqToDB.Data;

namespace dotnetProject.Services;

public class ClienteService : ICliente
{
    private readonly RepositorioGenerico<ClienteModel> _repositorio;

    public ClienteService(DataConnection conexao)
    {
        _repositorio = new RepositorioGenerico<ClienteModel>(conexao);
    }

    public async Task<IEnumerable<ClienteDTO>> ListarTodos()
    {
        var clientes = await _repositorio.Get();

        return clientes.Select(c => new ClienteDTO{
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

        return new ClienteDTO{
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

        return new ClienteDTO
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
    }

    public async Task Remover(long Id)
    {
        var clienteRemover = await _repositorio.GetById(Id);

        if (clienteRemover == null) {
            return;
        }

        await _repositorio.DeleteAsync(clienteRemover);
    }
}