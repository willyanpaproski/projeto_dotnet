using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Request;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresa _empresaService;

    private readonly ILogger<EmpresaController> _logger;

    public EmpresaController(ILogger<EmpresaController> logger, IEmpresa empresaService)
    {
        _logger = logger;
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpresaDTO>>> Get()
    {
        try
        {
            var empresas = await _empresaService.ListarTodos();
            return Ok(empresas);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar empresas");
            return StatusCode(500, $"Erro ao consultar empresas: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<EmpresaDTO?>> GetById(long Id)
    {
        try
        {
            var empresa = await _empresaService.ObterPorId(Id);
            if (empresa == null) {
                return NotFound("Empresa não encontrada");
            }
            return Ok(empresa);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar empresa");
            return StatusCode(500, $"Erro ao consultar empresa: ${ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<EmpresaDTO>> Criar([FromBody] EmpresaRequest request)
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

            var dto = new EmpresaCreateDTO
            {
                Ativo = request.Ativo,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                DataFundacao = request.DataFundacao,
                Cnpj = request.Cnpj,
                Cep = request.Cep,
                Endereco = request.Endereco,
                Numero = request.Numero,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Rua = request.Rua,
                Complemento = request.Complemento,
                Site = request.Site,
                Email = request.Email,
                Telefone = request.Telefone,
                Cor = request.Cor,
                Observacoes = request.Observacoes
            };

            var empresaCriada = await _empresaService.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { empresaCriada.Id }, empresaCriada);
        }   
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar empresa");
            return StatusCode(500, $"Erro ao cadastrar empresa: ${ex.Message}");
        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<EmpresaDTO?>> Atualizar(long Id, [FromBody] EmpresaRequest request)
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

            var dto = new EmpresaDTO
            {
                Ativo = request.Ativo,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                DataFundacao = request.DataFundacao,
                Cnpj = request.Cnpj,
                Cep = request.Cep,
                Endereco = request.Endereco,
                Numero = request.Numero,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Rua = request.Rua,
                Complemento = request.Complemento,
                Site = request.Site,
                Email = request.Email,
                Telefone = request.Telefone,
                Cor = request.Cor,
                Observacoes = request.Observacoes
            };

            var empresaAtualizada = await _empresaService.Atualizar(Id, dto);    

            if (empresaAtualizada == null) {
                return NotFound("Empresa não encontrada");
            }    

            return Ok(empresaAtualizada);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar empresa");
            return StatusCode(500, $"Erro ao atualizar empresa: ${ex.Message}");
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Remover(long Id)
    {
        try
        {
            var empresa = await _empresaService.ObterPorId(Id);

            if (empresa == null) {
                return NotFound("Empresa não encontrada");
            }

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar empresa");
            return StatusCode(500, $"Erro ao deletar empresa: ${ex.Message}");
        }
    }
}