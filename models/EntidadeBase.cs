using LinqToDB.Mapping;

namespace dotnetProject.Models;

[Table]
public abstract class EntidadeBase
{
    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [Column("UpdatedAt")]
    public DateTime UpdatedAt { get; set; }
}