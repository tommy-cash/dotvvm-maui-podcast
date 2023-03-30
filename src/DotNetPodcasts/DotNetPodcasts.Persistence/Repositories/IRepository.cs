using System.Linq.Expressions;

namespace DotNetPodcasts.Persistence.Repositories;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
    List<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression);
    TEntity GetById(int id, bool getRelatedEntities = true);
    int Save(TEntity item, bool updateRelated = true);
    int Delete(TEntity item);
    void DeleteAll();
}