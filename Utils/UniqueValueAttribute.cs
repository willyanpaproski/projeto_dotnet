using System.ComponentModel.DataAnnotations;

namespace dotnetProject.Utils
{
    public class UniqueValueAttribute<TModel> : ValidationAttribute where TModel : class
    {
        private readonly string _campo;
        private readonly string _campoId;

        public UniqueValueAttribute(string campo, string campoId = "Id")
        {
            _campo = campo;
            _campoId = campoId;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var repoTipo = typeof(Repository.RepositorioGenerico<>).MakeGenericType(typeof(TModel));
            var repo = validationContext.GetService(repoTipo);

            if (repo == null)
                throw new InvalidOperationException($"RepositorioGenerico<{typeof(TModel).Name}> não está registrado no DI.");

            var metodo = repoTipo.GetMethod("CampoExistenteAsync")!
                .MakeGenericMethod(value?.GetType() ?? typeof(string));

            var idProp = validationContext.ObjectType.GetProperty(_campoId);
            var idValor = idProp?.GetValue(validationContext.ObjectInstance) as long?;

            var task = (Task<bool>)metodo.Invoke(repo, new object?[] { _campo, value, idValor })!;
            var jaExiste = task.GetAwaiter().GetResult();

            if (jaExiste)
                return new ValidationResult(ErrorMessage ?? $"{_campo} já está em uso.");

            return ValidationResult.Success;
        }
    }
}
