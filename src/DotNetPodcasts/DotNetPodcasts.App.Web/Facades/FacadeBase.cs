using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNetPodcasts.App.Web.Mappers;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;

namespace DotNetPodcasts.App.Web.Facades;

public abstract class FacadeBase<TEntity, TDetailModel, TListModel> : IFacade<TDetailModel, TListModel>
    where TEntity : IEntity
    where TDetailModel : IModel
    where TListModel : IModel
{
    protected readonly IRepository<TEntity> repository;
    protected readonly IMapper<TEntity, TDetailModel, TListModel> mapper;

    public FacadeBase(IRepository<TEntity> repository, 
        IMapper<TEntity, TDetailModel, TListModel> mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    
    public List<TListModel> GetAll()
    {
        var entities = repository.GetAll();

        return entities
            .Select(mapper.MapToListModel)
            .ToList();
    }

    public TDetailModel GetById(int id)
    {
        var entity = repository.GetById(id);

        return mapper.MapToDetailModel(entity);
    }

    public int Save(TDetailModel item)
    {
        throw new System.NotImplementedException();
    }

    public int Delete(TDetailModel item)
    {
        throw new System.NotImplementedException();
    }
}