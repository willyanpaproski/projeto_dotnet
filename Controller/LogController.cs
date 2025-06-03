using dotnetProject.Dto;
using dotnetProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly ILog _logService;

    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger, ILog logService)
    {
        _logger = logger;
        _logService = logService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogDTO>>> Get()
    {
        try
        {
            var logs = await _logService.ListarTodos();
            return Ok(logs);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar os logs");
            return StatusCode(500, $"Erro ao consultar os logs: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<LogDTO?>> GetById(long Id)
    {
        try
        {
            var log = await _logService.ObterPorId(Id);

            if (log == null)
            {
                return NotFound("Log não encontrado");
            }

            return Ok(log);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar log");
            return StatusCode(500, $"Erro ao consultar log: ${ex.Message}");
        }
    }
}