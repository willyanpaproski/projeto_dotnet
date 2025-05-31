using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Request;
using Microsoft.AspNetCore.Mvc;

namespace dotnetProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _usuarioService;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuario usuarioService)
    {
        _usuarioService = usuarioService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
    {
        try
        {
            var usuarios = await _usuarioService.ListarTodos();
            return Ok(usuarios);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar os usuarios");
            return StatusCode(500, $"Erro ao consultar os usuarios: ${ex.Message}");
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<UsuarioDTO?>> GetById(long Id)
    {
        try
        {
            var usuario = await _usuarioService.ObterPorId(Id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(usuario);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar usuário");
            return StatusCode(500, $"Erro ao consultar usuário: ${ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> Create([FromBody] UsuarioRequest request)
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

            var dto = new UsuarioCreateDTO
            {
                Ativo = request.Ativo,
                Email = request.Email,
                NomeUsuario = request.NomeUsuario,
                SenhaHash = request.SenhaHash,
                LastLoggedIn = request.LastLoggedIn
            };

            var usuarioCriado = await _usuarioService.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { usuarioCriado.Id }, usuarioCriado);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao cadastrar usuário");
            return StatusCode(500, $"Erro ao cadastrar usuário: ${ex.Message}");
        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<UsuarioDTO?>> Update(long Id, [FromBody] UsuarioRequest request)
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

            var usuario = await _usuarioService.ObterPorId(Id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var dto = new UsuarioDTO
            {
                Ativo = request.Ativo,
                Email = request.Email,
                NomeUsuario = request.NomeUsuario,
                SenhaHash = request.SenhaHash,
                LastLoggedIn = request.LastLoggedIn
            };

            var usuarioAtualizado = await _usuarioService.Atualizar(Id, dto);

            return Ok(usuarioAtualizado);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar usuário");
            return StatusCode(500, $"Erro ao atualizar usuário: ${ex.Message}");
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(long Id)
    {
        try
        {
            var usuario = await _usuarioService.ObterPorId(Id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            await _usuarioService.Remover(Id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar usuário");
            return StatusCode(500, $"Erro ao deletar usuário: ${ex.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
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

            var usuario = await _usuarioService.LoginAsync(request);

            if (usuario.Usuario == null)
            {
                return Unauthorized("Email ou senha inválidos!");
            }

            return Ok(new
            {
                Message = "Login realizado com sucesso!",
                usuario.Token,
                usuario.Usuario
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao autenticar usuário");
            return StatusCode(500, $"Erro ao autenticar usuário: {ex.Message}");
        }
    }
}