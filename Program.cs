using System.Security.Claims;
using System.Text;
using dotnetProject.GraphQl;
using dotnetProject.Interfaces;
using dotnetProject.Repository;
using dotnetProject.Services;
using LinqToDB.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);
var secretKey = builder.Configuration["JwtSettings:SecretKey"];

builder.Services.AddScoped<DataConnection, LinqToDbDataConnection>();
builder.Services.AddScoped(typeof(RepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<FilialRepository>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IFilial, FilialService>();
builder.Services.AddScoped<ILog, LogService>();
builder.Services.AddScoped<LogService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryRegister>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();
app.MapControllers();

app.Run();
