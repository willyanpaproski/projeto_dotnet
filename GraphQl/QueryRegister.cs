namespace dotnetProject.GraphQl
{
    public class QueryRegister
    {
        public ClienteQuery ClienteQuery { get; set; } = new ClienteQuery();
        public EmpresaQuery EmpresaQuery { get; set; } = new EmpresaQuery();
        public FilialQuery FilialQuery { get; set; } = new FilialQuery();
        public LogQuery LogQuery { get; set; } = new LogQuery();
        public UsuarioQuery UsuarioQuery { get; set; } = new UsuarioQuery();
        public LogAcessoQuery LogAcessoQuery { get; set; } = new LogAcessoQuery();
    }
}
