using dotnetProject.GraphQl;
using dotnetProject.Interfaces;
using dotnetProject.Repository;
using dotnetProject.Services;
using LinqToDB.Data;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Registro de serviços
builder.Services.AddScoped<DataConnection, LinqToDbDataConnection>();
builder.Services.AddScoped(typeof(RepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<FilialRepository>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<IFilial, FilialService>();

// Configuração CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Queries do GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryRegister>();

// Adiciona controllers com suporte a Newtonsoft.Json
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

var app = builder.Build();

// Configuração CORS
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.UseRouting();

// Usando o GraphQL
app.MapGraphQL(); // Mapeia o GraphQL para o endpoint /graphql
app.MapControllers(); // Mapeia os endpoints dos controllers

app.Run();
