using dotnetProject.Dto;

namespace dotnetProject.Interfaces;

public interface IEmpresa
{
    Task<IEnumerable<EmpresaDTO>> ListarTodos();
    Task<EmpresaDTO?> ObterPorId(long Id);
    Task<EmpresaDTO> Criar(EmpresaCreateDTO empresa);
    Task<EmpresaDTO?> Atualizar(long Id, EmpresaDTO empresa);
    Task Remover(long Id);
}