using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Request;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class FilialController : ControllerBase
{
    private readonly IFilial _filialService;

    private readonly ILogger<FilialController> _logger;

    public FilialController(IFilial filialService, ILogger<FilialController> logger)
    {
        _filialService = filialService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilialDTO>>> Get()
    {
        try
        {
            var filiais = await _filialService.ListarTodos();
            return Ok(filiais);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar filiais");
            return StatusCode(500, $"Erro ao consultar filiais: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<FilialDTO?>> GetById(long Id)
    {
        try
        {
            var filial = await _filialService.ObterPorId(Id);

            if (filial == null) {
                return NotFound("Filial não encontrada");
            }

            return Ok(filial);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar filial");
            return StatusCode(500, $"Erro ao consultar filial: ${ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<FilialDTO>> Criar([FromBody] FilialRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    Message = "Erros de validação encontrados.",
                    Errors = errors
                });
            }

            var dto = new FilialCreateDTO
            {
                Ativo = request.Ativo,
                Nome = request.Nome,
                Cnpj = request.Cnpj,
                Cep = request.Cep,
                Endereco = request.Endereco,
                Numero = request.Numero,
                Rua = request.Rua,
                Cidade = request.Cidade,
                Estado = request.Estado,
                Bairro = request.Bairro,
                Complemento = request.Complemento,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Email = request.Email,
                DataAbertura = request.DataAbertura,
                Cor = request.Cor,
                NumeroInscricaoEstadual = request.NumeroInscricaoEstadual,
                NumeroInscricaoMunicipal = request.NumeroInscricaoMunicipal,
                NumeroAlvara = request.NumeroAlvara,
                Observacoes = request.Observacoes,
                EmpresaId = request.EmpresaId
            };

            var filialCriada = await _filialService.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { filialCriada.Id }, filialCriada);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar filial");
            return StatusCode(500, $"Erro ao cadastrar filial: ${ex.Message}");
        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<FilialDTO?>> Atualizar(long Id, FilialDTO dto)
    {
        try
        {
            var filialAtualizada = await _filialService.Atualizar(Id, dto);

            if (filialAtualizada == null) {
                return NotFound("Filial não encontrada");
            }

            return Ok(filialAtualizada);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar filial");
            return StatusCode(500, $"Erro ao atualizar filial: ${ex.Message}");
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Remover(long Id)
    {
        try
        {
            var filialRemover = await _filialService.ObterPorId(Id);

            if (filialRemover == null) {
                return NotFound("Filial não encontrada");
            }

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar filial");
            return StatusCode(500, $"Erro ao deletar filial: ${ex.Message}");
        }
    }
}