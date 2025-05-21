# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /app

# Copia o csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do projeto
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expor porta padrão da API
EXPOSE 80

ENTRYPOINT ["dotnet", "projeto_dot_net.dll"]
