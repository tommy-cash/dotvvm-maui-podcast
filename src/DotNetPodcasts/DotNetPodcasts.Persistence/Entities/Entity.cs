using SQLite;

namespace DotNetPodcasts.Persistence.Entities;

public abstract class Entity : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}