using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Request;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ICliente _clienteService;

    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger, ICliente clienteService) {
        _logger = logger;
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get() 
    {
        try
        {
            var clientes = await _clienteService.ListarTodos();
            return Ok(clientes);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar os clientes");
            return StatusCode(500, $"Erro ao consultar os clientes: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ClienteDTO?>> GetById(long Id)
    {
        try
        {
            var cliente = await _clienteService.ObterPorId(Id);

            if (cliente == null) {
                return NotFound("Cliente não encontrado");
            }

            return Ok(cliente);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar cliente");
            return StatusCode(500, $"Erro ao consultar cliente: ${ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDTO>> Criar([FromBody] ClienteRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    Message = "Erros de validação encontrados.",
                    Errors = errors
                });
            }

            var dto = new ClienteCreateDTO
            {
                Nome = request.Nome,
                Ativo = request.Ativo,
                CpfCnpj = request.CpfCnpj,
                DataNascimento = request.DataNascimento ?? default,
                TipoPessoa = request.TipoPessoa,
                Email = request.Email,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Cep = request.Cep,
                Endereco = request.Endereco,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Estado = request.Estado,
                Rua = request.Rua,
                Complemento = request.Complemento,
                EmpresaId = request.EmpresaId,
                FilialId = request.FilialId
            };

            var clienteCriado = await _clienteService.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { clienteCriado.Id }, clienteCriado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar cliente");
            return StatusCode(500, $"Erro ao cadastrar cliente: {ex.Message}");
        }
    }


    [HttpPut("{Id}")]
    public async Task<ActionResult<ClienteDTO?>> Atualizar(long Id, [FromBody] ClienteRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    Message = "Erros de validação encontrados.",
                    Errors = errors
                });
            }

            var cliente = await _clienteService.ObterPorId(Id);

            if (cliente == null) {
                return NotFound("Cliente não encontrado!");
            }

            var dto = new ClienteDTO
            {
                Ativo = request.Ativo,
                Nome = request.Nome,
                CpfCnpj = request.CpfCnpj,
                DataNascimento = request.DataNascimento ?? default,
                TipoPessoa = request.TipoPessoa,
                Email = request.Email,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Cep = request.Cep,
                Endereco = request.Endereco,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                Estado = request.Estado,
                Rua = request.Rua,
                Complemento = request.Complemento,
                EmpresaId = request.EmpresaId,
                FilialId = request.FilialId
            };

            var clienteAtualizado = await _clienteService.Atualizar(Id, dto);

            return Ok(clienteAtualizado);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar cliente");
            return StatusCode(500, $"Erro ao atualizar cliente: ${ex.Message}");
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Remover(long Id)
    {
        try
        {
            var cliente = await _clienteService.ObterPorId(Id);

            if (cliente == null) {
                return NotFound("Cliente não encontrado");
            }

            await _clienteService.Remover(Id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar cliente");
            return StatusCode(500, $"Erro ao deletar cliente: ${ex.Message}");
        }
    }
}