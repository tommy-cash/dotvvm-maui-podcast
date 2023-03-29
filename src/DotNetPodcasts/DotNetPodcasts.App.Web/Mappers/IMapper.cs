using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.App.Web.Mappers;

public interface IMapper<TEntity, TDetailModel, TListModel> 
    where TEntity : IEntity
    where TDetailModel : IModel
    where TListModel : IModel

{
    TEntity MapToEntity(TDetailModel model);
    TDetailModel MapToDetailModel(TEntity entity);
    TListModel MapToListModel(TEntity model);
}