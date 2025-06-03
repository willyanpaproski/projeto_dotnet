using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnetProject.Dto;
using dotnetProject.Interfaces;
using dotnetProject.Models;
using dotnetProject.Repository;
using dotnetProject.Request;
using LinqToDB.Data;
using Microsoft.IdentityModel.Tokens;

namespace dotnetProject.Services;

public class UsuarioService : IUsuario
{
    private readonly RepositorioGenerico<UsuarioModel> _repositorio;
    public LogService _logService;
    public LogAcessoService _logAcessoService;

    public UsuarioService(DataConnection conexao, LogService logService, LogAcessoService logAcessoService)
    {
        _repositorio = new RepositorioGenerico<UsuarioModel>(conexao);
        _logService = logService;
        _logAcessoService = logAcessoService;
    }

    public async Task<IEnumerable<UsuarioDTO>> ListarTodos()
    {
        var usuarios = await _repositorio.Get();

        return usuarios.OrderByDescending(u => u.Id).Select(u => new UsuarioDTO
        {
            Id = u.Id,
            Ativo = u.Ativo,
            Email = u.Email ?? "",
            NomeUsuario = u.NomeUsuario ?? "",
            SenhaHash = u.SenhaHash ?? "",
            LastLoggedIn = u.LastLoggedIn,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        });
    }

    public async Task<UsuarioDTO?> ObterPorId(long Id)
    {
        var usuario = await _repositorio.GetById(Id);

        if (usuario == null)
        {
            return null;
        }

        return new UsuarioDTO
        {
            Id = usuario.Id,
            Ativo = usuario.Ativo,
            Email = usuario.Email,
            NomeUsuario = usuario.NomeUsuario,
            SenhaHash = usuario.SenhaHash,
            LastLoggedIn = usuario.LastLoggedIn
        };
    }

    public async Task<UsuarioDTO> Criar(UsuarioCreateDTO dto)
    {
        var usuario = new UsuarioModel();

        string senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.SenhaHash);

        usuario.CriarModel(dto with { SenhaHash = senhaHash });

        var usuarioCriado = await _repositorio.CreateAsync(usuario);

        var retornoDto = new UsuarioDTO
        {
            Id = usuarioCriado.Id,
            Ativo = usuarioCriado.Ativo,
            Email = usuarioCriado.Email,
            NomeUsuario = usuarioCriado.NomeUsuario,
            LastLoggedIn = usuarioCriado.LastLoggedIn
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Usuario",
            TipoLog = TipoLogEnum.Cadastro,
            Usuario = "teste",
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task<UsuarioDTO?> Atualizar(long Id, UsuarioDTO dto)
    {
        var usuario = await _repositorio.GetById(Id);

        if (usuario == null)
        {
            return null;
        }

        usuario.AtualizarModel(dto);

        await _repositorio.UpdateAsync(usuario);

        var usuarioAtualizado = await _repositorio.GetById(Id);

        var retornoDto = new UsuarioDTO
        {
            Id = usuarioAtualizado.Id,
            Ativo = usuarioAtualizado.Ativo,
            Email = usuarioAtualizado.Email,
            NomeUsuario = usuarioAtualizado.NomeUsuario,
            LastLoggedIn = usuarioAtualizado.LastLoggedIn
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Usuario",
            TipoLog = TipoLogEnum.Atualizacao,
            Usuario = "teste",
            Campos = retornoDto.ToString()
        });

        return retornoDto;
    }

    public async Task Remover(long Id)
    {
        var usuarioRemover = await _repositorio.GetById(Id);

        if (usuarioRemover == null)
        {
            return;
        }

        var dto = new UsuarioDTO
        {
            Id = usuarioRemover.Id,
            Ativo = usuarioRemover.Ativo,
            Email = usuarioRemover.Email,
            NomeUsuario = usuarioRemover.NomeUsuario,
            SenhaHash = usuarioRemover.SenhaHash,
            LastLoggedIn = usuarioRemover.LastLoggedIn
        };

        await _logService.Criar(new LogCreateDTO
        {
            Tabela = "Usuario",
            TipoLog = TipoLogEnum.Deletou,
            Usuario = "teste",
            Campos = dto.ToString()
        });

        await _repositorio.DeleteAsync(usuarioRemover);
    }

    public async Task<(string? Token, UsuarioDTO? Usuario)> LoginAsync(UsuarioLoginRequest request)
    {
        var usuarios = await _repositorio.Get(q => q.Where(u => u.Email == request.Email));
        var usuario = usuarios.FirstOrDefault();

        if (usuario == null || usuario.Ativo == false)
        {
            return (null, null);
        }

        bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);

        if (!senhaValida)
        {
            return (null, null);
        }

        usuario.LastLoggedIn = DateTime.Now;
        await _repositorio.UpdateAsync(usuario);

        var token = GerarToken(usuario);

        var dto = new UsuarioDTO
        {
            Id = usuario.Id,
            Ativo = usuario.Ativo,
            Email = usuario.Email,
            NomeUsuario = usuario.NomeUsuario,
            LastLoggedIn = usuario.LastLoggedIn
        };

        await _logAcessoService.Criar(new LogAcessoCreateDTO
        {
            TipoLogAcesso = TipoLogAcessoEnum.Acesso,
            UsuarioId = usuario.Id
        });

        return (token, dto);
    }


    public string GerarToken(UsuarioModel usuario)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0q6Thorj6d4srGXRNDA5JNDjyhWF5wUR"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Name, usuario.NomeUsuario)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}