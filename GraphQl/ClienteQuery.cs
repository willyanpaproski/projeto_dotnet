using dotnetProject.Dto;
using dotnetProject.Enums.TipoPessoaEnum;
using dotnetProject.Interfaces;

namespace dotnetProject.GraphQl;

public class ClienteQuery 
{
    public async Task<IEnumerable<ClienteDTO>> PegarClientes(
        [Service] ICliente clienteService,
        long? id = null,
        FiltroOperador? idOperador = null,
        bool? ativo = null,
        FiltroOperador? ativoOperador = null,
        string? nome = null,
        FiltroOperador? nomeOperador = null,
        string? cpfCnpj = null,
        FiltroOperador? cpfCnpjOperador = null,
        string? dataNascimento = null,
        FiltroOperador? dataNascimentoOperador = null,
        TipoPessoaEnum? tipoPessoa = null,
        FiltroOperador? tipoPessoaOperador = null,
        string? email = null,
        FiltroOperador? emailOperador = null,
        string? telefone = null,
        FiltroOperador? telefoneOperador = null,
        string? celular = null,
        FiltroOperador? celularOperador = null,
        string? cep = null,
        FiltroOperador? cepOperador = null,
        string? endereco = null,
        FiltroOperador? enderecoOperador = null,
        string? cidade = null,
        FiltroOperador? cidadeOperador = null,
        string? bairro = null,
        FiltroOperador? bairroOperador = null,
        string? estado = null,
        FiltroOperador? estadoOperador = null,
        string? rua = null,
        FiltroOperador? ruaOperador = null,
        string? complemento = null,
        FiltroOperador? complementoOperador = null,
        long? empresaId = null,
        FiltroOperador? empresaIdOperador = null,
        long? filialId = null,
        FiltroOperador? filialIdOperador = null,
        string? createdAt = null,
        FiltroOperador? createdAtOperador = null,
        string? updatedAt = null,
        FiltroOperador? updatedAtOperador = null
    )
    {
        try
        {
            var clientes = await clienteService.ListarTodos();

            clientes = clientes
            .FiltrarLong(id, idOperador, c => c.Id)
            .FiltrarBool(ativo, ativoOperador, c => c.Ativo)
            .FiltrarString(nome, nomeOperador, c => c.Nome)
            .FiltrarString(cpfCnpj, cpfCnpjOperador, c => c.CpfCnpj)
            .FiltrarData(dataNascimento, dataNascimentoOperador, c => c.DataNascimento)
            .FiltrarEnum(tipoPessoa, tipoPessoaOperador, c => c.TipoPessoa)
            .FiltrarString(email, emailOperador, c => c.Email)
            .FiltrarString(telefone, telefoneOperador, c => c.Telefone)
            .FiltrarString(celular, celularOperador, c => c.Celular)
            .FiltrarString(cep, cepOperador, c => c.Cep)
            .FiltrarString(endereco, enderecoOperador, c => c.Endereco)
            .FiltrarString(cidade, cidadeOperador, c => c.Cidade)
            .FiltrarString(bairro, bairroOperador, c => c.Bairro)
            .FiltrarString(estado, estadoOperador, c => c.Estado)
            .FiltrarString(rua, ruaOperador, c => c.Rua)
            .FiltrarString(complemento, complementoOperador, c => c.Complemento)
            .FiltrarLong(empresaId, empresaIdOperador, c => c.EmpresaId)
            .FiltrarLong(filialId, filialIdOperador, c => c.FilialId)
            .FiltrarDateTime(createdAt, createdAtOperador, c => c.CreatedAt)
            .FiltrarDateTime(updatedAt, updatedAtOperador, c => c.UpdatedAt);

            return clientes;
        }
        catch (System.Exception ex)
        {
            throw new GraphQLException($"Erro ao buscar clientes: ${ex.Message}");
        }
    }
}