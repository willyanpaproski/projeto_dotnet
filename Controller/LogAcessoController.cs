using dotnetProject.Dto;
using dotnetProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class LogAcessoController : ControllerBase
{
    private readonly ILogAcesso _logAcessoService;

    private readonly ILogger<LogAcessoController> _logger;

    public LogAcessoController(ILogger<LogAcessoController> logger, ILogAcesso logAcessoService)
    {
        _logAcessoService = logAcessoService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogAcessoDTO>>> Get()
    {
        try
        {
            var logsAcesso = await _logAcessoService.ListarTodos();
            return Ok(logsAcesso);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar os logs de acesso");
            return StatusCode(500, $"Erro ao consultar os logs de acesso: ${ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogAcessoDTO>>> GetWithUsuario()
    {
        try
        {
            var logsAcessoComUsuario = await _logAcessoService.ListarLogsAcessoComUsuario();
            return Ok(logsAcessoComUsuario);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar os logs de acesso com usuário");
            return StatusCode(500, $"Erro ao consultar os logs de acesso com usuário: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<LogAcessoDTO?>> GetById(long Id)
    {
        try
        {
            var logAcesso = await _logAcessoService.ObterPorId(Id);

            if (logAcesso == null)
            {
                return NotFound("Log de acesso não encontrado");
            }

            return Ok(logAcesso);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar log de acesso");
            return StatusCode(500, $"Erro ao consultar log de acesso: ${ex.Message}");
        }
    }

    [HttpGet("/api/logAcesso/logsAcessoComUsuario/{Id}")]
    public async Task<ActionResult<LogAcessoDTO?>> GetWithUsuarioById(long Id)
    {
        try
        {
            var logAcessoComUsuario = await _logAcessoService.ObterLogAcessoComUsuarioById(Id);

            if (logAcessoComUsuario == null)
            {
                return NotFound("Log de acesso com usuário não encontrado");
            }

            return Ok(logAcessoComUsuario);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar log de acesso com usuário");
            return StatusCode(500, $"Erro ao consultar log de acesso com usuário: ${ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<LogAcessoDTO>> CreateLogoutLog([FromBody] LogAcessoCreateDTO logAcesso)
    {
        try
        {
            var dto = new LogAcessoCreateDTO
            {
                TipoLogAcesso = TipoLogAcessoEnum.Logout,
                UsuarioId = logAcesso.UsuarioId,
                Usuario = logAcesso.Usuario
            };

            var logLogoutCriado = await _logAcessoService.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { logLogoutCriado.Id }, logLogoutCriado);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar log de logout");
            return StatusCode(500, $"Erro ao consultar log de logout: ${ex.Message}");
        }
    }
}