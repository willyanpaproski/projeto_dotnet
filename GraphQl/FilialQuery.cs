using dotnetProject.Dto;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class FilialQuery
{
    public async Task<IEnumerable<FilialDTO>> PegarFiliais(
        [Service] IFilial filialService,
        long? id = null,
        FiltroOperador? idOperador = null,
        bool? ativo = null,
        FiltroOperador? ativoOperador = null,
        string? nome = null,
        FiltroOperador? nomeOperador = null,
        string? cnpj = null,
        FiltroOperador? cnpjOperador = null,
        string? cep = null,
        FiltroOperador? cepOperador = null,
        string? endereco = null,
        FiltroOperador? enderecoOperador = null,
        string? numero = null,
        FiltroOperador? numeroOperador = null,
        string? rua = null,
        FiltroOperador? ruaOperador = null,
        string? cidade = null,
        FiltroOperador? cidadeOperador = null,
        string? estado = null,
        FiltroOperador? estadoOperador = null,
        string? bairro = null,
        FiltroOperador? bairroOperador = null,
        string? complemento = null,
        FiltroOperador? complementoOperador = null,
        string? telefone = null,
        FiltroOperador? telefoneOperador = null,
        string? celular = null,
        FiltroOperador? celularOperador = null,
        string? email = null,
        FiltroOperador? emailOperador = null,
        string? dataAbertura = null,
        FiltroOperador? dataAberturaOperador = null,
        string? cor = null,
        FiltroOperador? corOperador = null,
        string? numeroInscricaoEstadual = null,
        FiltroOperador? numeroInscricaoEstadualOperador = null,
        string? numeroInscricaoMunicipal = null,
        FiltroOperador? numeroInscricaoMunicipalOperador = null,
        string? numeroAlvara = null,
        FiltroOperador? numeroAlvaraOperador = null,
        string? observacoes = null,
        FiltroOperador? observacoesOperador = null,
        long? empresaId = null,
        FiltroOperador? empresaIdOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null,
        string? updatedAt = null,
        FiltroOperador? updatedAtOperador = null
    )
    {
        try
        {
            var filiais = await filialService.ListarTodos();

            filiais = filiais
            .FiltrarLong(id, idOperador, f => f.Id)
            .FiltrarBool(ativo, ativoOperador, f => f.Ativo)
            .FiltrarString(nome, nomeOperador, f => f.Nome)
            .FiltrarString(cnpj, cnpjOperador, f => f.Cnpj)
            .FiltrarString(cep, cepOperador, f => f.Cep)
            .FiltrarString(endereco, enderecoOperador, f => f.Endereco)
            .FiltrarString(numero, numeroOperador, f => f.Numero)
            .FiltrarString(rua, ruaOperador, f => f.Rua)
            .FiltrarString(cidade, cidadeOperador, f => f.Cidade)
            .FiltrarString(estado, estadoOperador, f => f.Estado)
            .FiltrarString(bairro, bairroOperador, f => f.Bairro)
            .FiltrarString(complemento, complementoOperador, f => f.Complemento)
            .FiltrarString(telefone, telefoneOperador, f => f.Telefone)
            .FiltrarString(celular, celularOperador, f => f.Celular)
            .FiltrarString(email, emailOperador, f => f.Email)
            .FiltrarData(dataAbertura, dataAberturaOperador, f => f.DataAbertura)
            .FiltrarString(cor, corOperador, f => f.Cor)
            .FiltrarString(numeroInscricaoEstadual, numeroInscricaoEstadualOperador, f => f.NumeroInscricaoEstadual)
            .FiltrarString(numeroInscricaoMunicipal, numeroInscricaoMunicipalOperador, f => f.NumeroInscricaoMunicipal)
            .FiltrarString(numeroAlvara, numeroAlvaraOperador, f => f.NumeroAlvara)
            .FiltrarString(observacoes, observacoesOperador, f => f.Observacoes)
            .FiltrarLong(empresaId, empresaIdOperador, f => f.EmpresaId)
            .FiltrarDateTime(createdAt, createdAtOperador, f => f.CreatedAt)
            .FiltrarDateTime(updatedAt, updatedAtOperador, f => f.UpdatedAt);

            return filiais;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar filiais: ${ex.Message}");
        }
    }

    public async Task<IEnumerable<FilialDTO>> PegarFiliaisComEmpresa(
        [Service] IFilial filialService,
        long? id = null,
        FiltroOperador? idOperador = null,
        bool? ativo = null,
        FiltroOperador? ativoOperador = null,
        string? nome = null,
        FiltroOperador? nomeOperador = null,
        string? cnpj = null,
        FiltroOperador? cnpjOperador = null,
        string? cep = null,
        FiltroOperador? cepOperador = null,
        string? endereco = null,
        FiltroOperador? enderecoOperador = null,
        string? numero = null,
        FiltroOperador? numeroOperador = null,
        string? rua = null,
        FiltroOperador? ruaOperador = null,
        string? cidade = null,
        FiltroOperador? cidadeOperador = null,
        string? estado = null,
        FiltroOperador? estadoOperador = null,
        string? bairro = null,
        FiltroOperador? bairroOperador = null,
        string? complemento = null,
        FiltroOperador? complementoOperador = null,
        string? telefone = null,
        FiltroOperador? telefoneOperador = null,
        string? celular = null,
        FiltroOperador? celularOperador = null,
        string? email = null,
        FiltroOperador? emailOperador = null,
        string? dataAbertura = null,
        FiltroOperador? dataAberturaOperador = null,
        string? cor = null,
        FiltroOperador? corOperador = null,
        string? numeroInscricaoEstadual = null,
        FiltroOperador? numeroInscricaoEstadualOperador = null,
        string? numeroInscricaoMunicipal = null,
        FiltroOperador? numeroInscricaoMunicipalOperador = null,
        string? numeroAlvara = null,
        FiltroOperador? numeroAlvaraOperador = null,
        string? observacoes = null,
        FiltroOperador? observacoesOperador = null,
        long? empresaId = null,
        FiltroOperador? empresaIdOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null,
        string? updatedAt = null,
        FiltroOperador? updatedAtOperador = null,
        string? razaoSocialEmpresa = null,
        FiltroOperador? razaoSocialEmpresaOperador = null
    )
    {
        try
        {
            var filiais = await filialService.GetFiliaisComEmpresa();

            filiais = filiais
            .FiltrarLong(id, idOperador, f => f.Id)
            .FiltrarBool(ativo, ativoOperador, f => f.Ativo)
            .FiltrarString(nome, nomeOperador, f => f.Nome)
            .FiltrarString(cnpj, cnpjOperador, f => f.Cnpj)
            .FiltrarString(cep, cepOperador, f => f.Cep)
            .FiltrarString(endereco, enderecoOperador, f => f.Endereco)
            .FiltrarString(numero, numeroOperador, f => f.Numero)
            .FiltrarString(rua, ruaOperador, f => f.Rua)
            .FiltrarString(cidade, cidadeOperador, f => f.Cidade)
            .FiltrarString(estado, estadoOperador, f => f.Estado)
            .FiltrarString(bairro, bairroOperador, f => f.Bairro)
            .FiltrarString(complemento, complementoOperador, f => f.Complemento)
            .FiltrarString(telefone, telefoneOperador, f => f.Telefone)
            .FiltrarString(celular, celularOperador, f => f.Celular)
            .FiltrarString(email, emailOperador, f => f.Email)
            .FiltrarData(dataAbertura, dataAberturaOperador, f => f.DataAbertura)
            .FiltrarString(cor, corOperador, f => f.Cor)
            .FiltrarString(numeroInscricaoEstadual, numeroInscricaoEstadualOperador, f => f.NumeroInscricaoEstadual)
            .FiltrarString(numeroInscricaoMunicipal, numeroInscricaoMunicipalOperador, f => f.NumeroInscricaoMunicipal)
            .FiltrarString(numeroAlvara, numeroAlvaraOperador, f => f.NumeroAlvara)
            .FiltrarString(observacoes, observacoesOperador, f => f.Observacoes)
            .FiltrarLong(empresaId, empresaIdOperador, f => f.EmpresaId)
            .FiltrarDateTime(createdAt, createdAtOperador, f => f.CreatedAt)
            .FiltrarDateTime(updatedAt, updatedAtOperador, f => f.UpdatedAt)
            .FiltrarString(razaoSocialEmpresa, razaoSocialEmpresaOperador, f => f.Empresa.RazaoSocial);

            return filiais;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar filiais: ${ex.Message}");
        }
    }
}