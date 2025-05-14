using System.Reflection;
using LinqToDB;
using LinqToDB.Data;
using System.Linq.Expressions;
using dotnetProject.Models;

namespace dotnetProject.Repository.RepositorioGenerico;

public class RepositorioGenerico<T> where T : EntidadeBase
{
    protected readonly DataConnection _conexao;

    public RepositorioGenerico(DataConnection conexao)
    {
        _conexao = conexao;
    }

    public async Task<IEnumerable<T>> Get(Func<IQueryable<T>, IQueryable<T>>? filter = null)
    {
        var query = _conexao.GetTable<T>().AsQueryable();

        if (filter != null) {
            query = filter(query);
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetById(long Id)
    {
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(p => p.GetCustomAttribute<LinqToDB.Mapping.PrimaryKeyAttribute>() != null ||
                                p.GetCustomAttribute<LinqToDB.Mapping.ColumnAttribute>()?.IsPrimaryKey == true);

        if (keyProperty == null)
        {
            throw new InvalidOperationException("T não possui uma propriedade marcada como chave primária.");
        }

        var keyValue = Expression.Parameter(typeof(T), "x");
        var propertyAccess = Expression.Property(keyValue, keyProperty);

        var idExpression = Expression.Constant(Id, typeof(long));

        var equalsExpression = Expression.Equal(propertyAccess, idExpression);
        var lambda = Expression.Lambda<Func<T, bool>>(equalsExpression, keyValue);

        var result = await _conexao.GetTable<T>().Where(lambda).FirstOrDefaultAsync();

        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<T> CreateAsync(T entidade) {
        var now = DateTime.Now;
        entidade.CreatedAt = now;
        entidade.UpdatedAt = now;

        var id = await _conexao.InsertWithIdentityAsync<T>(entidade);

        var keyProperty = typeof(T).GetProperties()
        .FirstOrDefault(p => p.GetCustomAttribute<LinqToDB.Mapping.PrimaryKeyAttribute>() != null ||
        p.GetCustomAttribute<LinqToDB.Mapping.ColumnAttribute>()?.IsPrimaryKey == true);

        if (keyProperty != null && id != null) {
            keyProperty.SetValue(entidade, Convert.ChangeType(id, keyProperty.PropertyType));
        }

        return entidade;
    }

    public async Task UpdateAsync(T entidade) {
        var now = DateTime.Now;
        entidade.UpdatedAt = now;
        await _conexao.UpdateAsync<T>(entidade);
    }

    public async Task DeleteAsync(T entidade) {
        await _conexao.DeleteAsync<T>(entidade);
    }
}