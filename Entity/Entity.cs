using System.ComponentModel.DataAnnotations;

namespace Entity;

public abstract class Entity : IEntity
{
    [Key]
    public int Id { get; set; }
}