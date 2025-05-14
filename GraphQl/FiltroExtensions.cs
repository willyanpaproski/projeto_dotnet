namespace dotnetProject.GraphQl;

public static class FiltroExtensions
{
    public static IEnumerable<T> FiltrarString<T>(
        this IEnumerable<T> source, 
        string? valor,
        FiltroOperador? operador,
        Func<T, string?> selector
    )
    {
        if (string.IsNullOrEmpty(valor) || !operador.HasValue) {
            return source;
        }

        return operador switch
        {
            FiltroOperador.Igual => source.Where(x => selector(x)?.Equals(valor, StringComparison.OrdinalIgnoreCase) == true),
            FiltroOperador.Diferente => source.Where(x => selector(x)?.Equals(valor, StringComparison.OrdinalIgnoreCase) != true),
            FiltroOperador.Contem => source.Where(x => selector(x)?.Contains(valor, StringComparison.OrdinalIgnoreCase) == true),
            FiltroOperador.NaoContem => source.Where(x => selector(x)?.Contains(valor, StringComparison.OrdinalIgnoreCase) != true),
            _ => source
        };
    }

    public static IEnumerable<T> FiltrarLong<T>(
        this IEnumerable<T> source,
        long? valor,
        FiltroOperador? operador,
        Func<T, long> selector
    )
    {   
        if (!valor.HasValue || !operador.HasValue) {
            return source;
        }

        return operador switch
        {
            FiltroOperador.Igual => source.Where(x => selector(x) == valor),
            FiltroOperador.Diferente => source.Where(x => selector(x) != valor),
            FiltroOperador.MaiorQue => source.Where(x => selector(x) > valor),
            FiltroOperador.MenorQue => source.Where(x => selector(x) < valor),
            FiltroOperador.MaiorIgual => source.Where(x => selector(x) >= valor),
            FiltroOperador.MenorIgual => source.Where(x => selector(x) <= valor),
            _ => source
        };
    }

    public static IEnumerable<T> FiltrarBool<T>(
        this IEnumerable<T> source,
        bool? valor, 
        FiltroOperador? operador,
        Func<T, bool> selector
    )
    {
        if (!valor.HasValue || !operador.HasValue) {
            return source;
        }

        return operador switch
        {
            FiltroOperador.Igual => source.Where(x => selector(x) == valor),
            FiltroOperador.Diferente => source.Where(x => selector(x) != valor),
            _ => source
        };
    }

    public static IEnumerable<T> FiltrarEnum<T, TEnum>(
        this IEnumerable<T> source,
        TEnum? valor,
        FiltroOperador? operador,
        Func<T, TEnum> selector
    ) where TEnum : struct, Enum
    {   
        if (!valor.HasValue || !operador.HasValue) {
            return source;
        }

        return operador switch
        {
            FiltroOperador.Igual => source.Where(x => selector(x).Equals(valor.Value)),
            FiltroOperador.Diferente => source.Where(x => !selector(x).Equals(valor.Value))
        };
    }

    public static IEnumerable<T> FiltrarData<T>(
        this IEnumerable<T> source,
        string? valor,
        FiltroOperador? operador,
        Func<T, DateOnly?> selector
    )
    {
        if (string.IsNullOrEmpty(valor) || !operador.HasValue) {
            return source;
        }

        if (!DateOnly.TryParseExact(valor, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var data)) {
            return source;
        }

        return operador switch
        {
            FiltroOperador.Igual => source.Where(x => selector(x) == data),
            FiltroOperador.Diferente => source.Where(x => selector(x) != data),
            FiltroOperador.MaiorQue => source.Where(x => selector(x) > data),
            FiltroOperador.MenorQue => source.Where(x => selector(x) < data),
            FiltroOperador.MaiorIgual => source.Where(x => selector(x) >= data),
            FiltroOperador.MenorIgual => source.Where(x => selector(x) <= data),
            _ => source
        };
    }

    public static IEnumerable<T> FiltrarDateTime<T>(
        this IEnumerable<T> source,
        string? valor,
        FiltroOperador? operador,
        Func<T, DateTime?> selector
    )
    {   
        if (string.IsNullOrEmpty(valor) || !operador.HasValue) {
            return source;
        }

        if (!DateTime.TryParse(valor, out var dataHora)) {
            return source;
        }

        return operador switch 
        {
            FiltroOperador.Igual => source.Where(x => selector(x) == dataHora),
            FiltroOperador.Diferente => source.Where(x => selector(x) != dataHora),
            FiltroOperador.MaiorQue => source.Where(x => selector(x) > dataHora),
            FiltroOperador.MenorQue => source.Where(x => selector(x) < dataHora),
            FiltroOperador.MaiorIgual => source.Where(x => selector(x) >= dataHora),
            FiltroOperador.MenorIgual => source.Where(x => selector(x) <= dataHora),
            _ => source
        };
    }
}