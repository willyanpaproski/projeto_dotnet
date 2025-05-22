using dotnetProject.Dto;

namespace dotnetProject.Interfaces;

public interface IFilial
{
    Task<IEnumerable<FilialDTO>> ListarTodos();
    Task<FilialDTO?> ObterPorId(long Id);
    Task<FilialDTO> Criar(FilialCreateDTO filial);
    Task<FilialDTO?> Atualizar(long Id, FilialDTO filial);
    Task Remover(long Id);
    Task<IEnumerable<FilialDTO>> GetFiliaisComEmpresa();
}