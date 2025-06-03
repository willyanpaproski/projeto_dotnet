using LinqToDB;
using LinqToDB.Data;
using dotnetProject.Models;

public class LinqToDbDataConnection : DataConnection
{
    public LinqToDbDataConnection(IConfiguration configuration)
    : base(ProviderName.SqlServer, configuration.GetConnectionString("Default"))
    {
    }

    public ITable<ClienteModel> ClienteModels => this.GetTable<ClienteModel>();
    public ITable<EmpresaModel> EmpresaModels => this.GetTable<EmpresaModel>();
    public ITable<FilialModel> FilialModels => this.GetTable<FilialModel>();
    public ITable<LogModel> LogModels => this.GetTable<LogModel>();
    public ITable<UsuarioModel> UsuarioModels => this.GetTable<UsuarioModel>();
    public ITable<LogAcessoModel> LogAcessoModels => this.GetTable<LogAcessoModel>();
}
