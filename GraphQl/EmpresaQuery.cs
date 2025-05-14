using dotnetProject.Dto;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class EmpresaQuery
{
    public async Task<IEnumerable<EmpresaDTO>> PegarEmpresas(
        [Service] IEmpresa empresaService,
        long? id = null,
        FiltroOperador? idOperador = null,
        bool? ativo = null,
        FiltroOperador? ativoOperador = null,
        string? razaoSocial = null,
        FiltroOperador? razaoSocialOperador = null,
        string? nomeFantasia = null,
        FiltroOperador? nomeFantasiaOperador = null,
        string? dataFundacao = null,
        FiltroOperador? dataFundacaoOperador = null,
        string? cnpj = null,
        FiltroOperador? cnpjOperador = null,
        string? cep = null,
        FiltroOperador? cepOperador = null,
        string? endereco = null,
        FiltroOperador? enderecoOperador = null,
        string? numero = null,
        FiltroOperador? numeroOperador = null,
        string? cidade = null,
        FiltroOperador? cidadeOperador = null,
        string? bairro = null,
        FiltroOperador? bairroOperador = null,
        string? rua = null,
        FiltroOperador? ruaOperador = null,
        string? complemento = null,
        FiltroOperador? complementoOperador = null,
        string? site = null,
        FiltroOperador? siteOperador = null,
        string? email = null,
        FiltroOperador? emailOperador = null,
        string? telefone = null,
        FiltroOperador? telefoneOperador = null,
        string? cor = null,
        FiltroOperador? corOperador = null,
        string? observacoes = null,
        FiltroOperador? observacoesOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null,
        string? updatedAt = null,
        FiltroOperador? updatedAtOperador = null
    )
    {
        try
        {
            var empresas = await empresaService.ListarTodos();

            empresas = empresas
            .FiltrarLong(id, idOperador, e => e.Id)
            .FiltrarBool(ativo, ativoOperador, e => e.Ativo)
            .FiltrarString(razaoSocial, razaoSocialOperador, e => e.RazaoSocial)
            .FiltrarString(nomeFantasia, nomeFantasiaOperador, e => e.NomeFantasia)
            .FiltrarData(dataFundacao, dataFundacaoOperador, e => e.DataFundacao)
            .FiltrarString(cnpj, cnpjOperador, e => e.Cnpj)
            .FiltrarString(cep, cepOperador, e => e.Cep)
            .FiltrarString(endereco, enderecoOperador, e => e.Endereco)
            .FiltrarString(numero, numeroOperador, e => e.Numero)
            .FiltrarString(cidade, cidadeOperador, e => e.Cidade)
            .FiltrarString(bairro, bairroOperador, e => e.Bairro)
            .FiltrarString(rua, ruaOperador, e => e.Rua)
            .FiltrarString(complemento, complementoOperador, e => e.Complemento)
            .FiltrarString(site, siteOperador, e => e.Site)
            .FiltrarString(email, emailOperador, c => c.Email)
            .FiltrarString(telefone, telefoneOperador, c => c.Telefone)
            .FiltrarString(cor, corOperador, e => e.Cor)
            .FiltrarString(observacoes, observacoesOperador, c => c.Observacoes)
            .FiltrarDateTime(createdAt, createdAtOperador, e => e.CreatedAt)
            .FiltrarDateTime(updatedAt, updatedAtOperador, e => e.UpdatedAt);

            return empresas;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar empresas: ${ex.Message}");
        }
    }
}