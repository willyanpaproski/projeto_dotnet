using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository.RepositorioGenerico;
using LinqToDB.Data;

namespace dotnetProject.Services;

public class EmpresaService : IEmpresa
{
    private readonly RepositorioGenerico<EmpresaModel> _repositorio;

    public EmpresaService(DataConnection conexao)
    {
        _repositorio = new RepositorioGenerico<EmpresaModel>(conexao);
    }

    public async Task<IEnumerable<EmpresaDTO>> ListarTodos()
    {
        var empresas = await _repositorio.Get();

        return empresas.Select(e => new EmpresaDTO{
            Id = e.Id,
            Ativo = e.Ativo,
            RazaoSocial = e.RazaoSocial ?? "",
            NomeFantasia = e.NomeFantasia ?? "",
            DataFundacao = e.DataFundacao,
            Cnpj = e.Cnpj ?? "",
            Cep = e.Cep ?? "",
            Endereco = e.Endereco ?? "",
            Numero = e.Numero ?? "",
            Cidade = e.Cidade ?? "",
            Bairro = e.Bairro ?? "",
            Rua = e.Rua ?? "",
            Complemento = e.Complemento ?? "",
            Site = e.Site ?? "",
            Email = e.Email ?? "",
            Telefone = e.Telefone ?? "",
            Cor = e.Cor ?? "",
            Observacoes = e.Observacoes ?? "",
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        });
    }

    public async Task<EmpresaDTO?> ObterPorId(long Id)
    {
        var empresa = await _repositorio.GetById(Id);

        if (empresa == null) {
            return null;
        } 

        return new EmpresaDTO{
            Id = empresa.Id,
            Ativo = empresa.Ativo,
            RazaoSocial = empresa.RazaoSocial ?? "",
            NomeFantasia = empresa.NomeFantasia ?? "",
            DataFundacao = empresa.DataFundacao,
            Cnpj = empresa.Cnpj ?? "",
            Cep = empresa.Cep ?? "",
            Endereco = empresa.Endereco ?? "",
            Numero = empresa.Numero ?? "",
            Cidade = empresa.Cidade ?? "",
            Bairro = empresa.Bairro ?? "",
            Rua = empresa.Rua ?? "",
            Complemento = empresa.Complemento ?? "",
            Site = empresa.Site ?? "",
            Email = empresa.Email ?? "",
            Telefone = empresa.Telefone ?? "",
            Cor = empresa.Cor ?? "",
            Observacoes = empresa.Observacoes ?? "",
            CreatedAt = empresa.CreatedAt,
            UpdatedAt = empresa.UpdatedAt
        };
    }

    public async Task<EmpresaDTO> Criar(EmpresaCreateDTO dto)
    {
        var empresa = new EmpresaModel();
        empresa.CriarModel(dto);

        var empresaCriada = await _repositorio.CreateAsync(empresa);

        return new EmpresaDTO{
            Id = empresaCriada.Id,
            Ativo = empresaCriada.Ativo,
            RazaoSocial = empresaCriada.RazaoSocial ?? "",
            NomeFantasia = empresaCriada.NomeFantasia ?? "",
            DataFundacao = empresaCriada.DataFundacao,
            Cnpj = empresaCriada.Cnpj ?? "",
            Cep = empresaCriada.Cep ?? "",
            Endereco = empresaCriada.Endereco ?? "",
            Numero = empresaCriada.Numero ?? "",
            Cidade = empresaCriada.Cidade ?? "",
            Bairro = empresaCriada.Bairro ?? "",
            Rua = empresaCriada.Rua ?? "",
            Complemento = empresaCriada.Complemento ?? "",
            Site = empresaCriada.Site ?? "",
            Email = empresaCriada.Email ?? "",
            Telefone = empresaCriada.Telefone ?? "",
            Cor = empresaCriada.Cor ?? "",
            Observacoes = empresaCriada.Observacoes ?? "",
            CreatedAt = empresaCriada.CreatedAt,
            UpdatedAt = empresaCriada.UpdatedAt
        };
    }

    public async Task<EmpresaDTO?> Atualizar(long Id, EmpresaDTO dto)
    {
        var empresa = await _repositorio.GetById(Id);

        if (empresa == null) {
            return null;
        }

        empresa.AtualizarModel(dto);

        await _repositorio.UpdateAsync(empresa);

        var empresaAtualizada = await _repositorio.GetById(Id);

        return new EmpresaDTO{
            Id = empresaAtualizada.Id,
            Ativo = empresaAtualizada.Ativo,
            RazaoSocial = empresaAtualizada.RazaoSocial ?? "",
            NomeFantasia = empresaAtualizada.NomeFantasia ?? "",
            DataFundacao = empresaAtualizada.DataFundacao,
            Cnpj = empresaAtualizada.Cnpj ?? "",
            Cep = empresaAtualizada.Cep ?? "",
            Endereco = empresaAtualizada.Endereco ?? "",
            Numero = empresaAtualizada.Numero ?? "",
            Cidade = empresaAtualizada.Cidade ?? "",
            Bairro = empresaAtualizada.Bairro ?? "",
            Rua = empresaAtualizada.Rua ?? "",
            Complemento = empresaAtualizada.Complemento ?? "",
            Site = empresaAtualizada.Site ?? "",
            Email = empresaAtualizada.Email ?? "",
            Telefone = empresaAtualizada.Telefone ?? "",
            Cor = empresaAtualizada.Cor ?? "",
            Observacoes = empresaAtualizada.Observacoes ?? "",
            CreatedAt = empresaAtualizada.CreatedAt,
            UpdatedAt = empresaAtualizada.UpdatedAt
        };
    }

    public async Task Remover(long Id) 
    {
        var empresaRemover = await _repositorio.GetById(Id);

        if (empresaRemover == null) {
            return;
        }

        await _repositorio.DeleteAsync(empresaRemover);
    }
}