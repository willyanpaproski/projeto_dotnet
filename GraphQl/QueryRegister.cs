namespace dotnetProject.GraphQl
{
    public class QueryRegister
    {
        public ClienteQuery ClienteQuery { get; set; } = new ClienteQuery();
        public EmpresaQuery EmpresaQuery { get; set; } = new EmpresaQuery();
        public FilialQuery FilialQuery { get; set; } = new FilialQuery();
    }
}
