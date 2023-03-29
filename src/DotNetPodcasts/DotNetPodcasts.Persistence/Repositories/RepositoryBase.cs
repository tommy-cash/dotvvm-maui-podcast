using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Entities;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Linq.Expressions;

namespace DotNetPodcasts.Persistence.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : Entity, new()
{
    private readonly DatabaseConfiguration databaseConfiguration;
    protected SQLiteConnection Database;

    public RepositoryBase(DatabaseConfiguration databaseConfiguration)
    {
        this.databaseConfiguration = databaseConfiguration;
        Init();
    }

    protected virtual void Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteConnection(databaseConfiguration.DatabasePath, DatabaseConfiguration.Flags);
        var result = Database.CreateTable<TEntity>();
    }
    
    public List<TEntity> GetAll()
    {
        Init();
        return Database.Table<TEntity>().ToList();
    }

    public List<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression)
    {
        Init();
        return Database.Table<TEntity>().Where(expression).ToList();
    }
    
    public TEntity GetById(int id, bool getRelatedEntities = true)
    {
        Init();

        if (getRelatedEntities)
        {
            return Database.GetWithChildren<TEntity>(id);
        }

        return Database.Table<TEntity>().Where(i => i.Id == id).FirstOrDefault();
    }

    public int Save(TEntity item, bool updateRelated = true)
    {
        Init();

        if (item.Id == default)
        {
            if (updateRelated)
            {
                Database.InsertWithChildren(item);
                return item.Id;
            }

            return Database.Insert(item);
        }

        if (updateRelated)
        {
            Database.UpdateWithChildren(item);
            return item.Id;
        }
        
        return Database.Update(item);
    }

    public int Delete(TEntity item)
    {
        Init();

        return Database.Delete(item);
    }

    public void DeleteAll()
    {
        Init();

        Database.DeleteAll<TEntity>();
    }
}