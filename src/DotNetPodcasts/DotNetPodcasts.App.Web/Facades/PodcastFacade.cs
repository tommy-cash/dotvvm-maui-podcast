using DotNetPodcasts.App.Web.Mappers;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DotNetPodcasts.App.Web.Facades;

public class PodcastFacade : FacadeBase<PodcastEntity, PodcastDetailModel, PodcastListModel>
{
    public PodcastFacade(IRepository<PodcastEntity> repository, IMapper<PodcastEntity, PodcastDetailModel, PodcastListModel> mapper)
        : base(repository, mapper)
    {
    }

    public void ToggleSubscribe(int id)
    {
        var podcast = repository.GetById(id, false);
        podcast.IsSubscribed = !podcast.IsSubscribed;

        repository.Save(podcast, false);
    }

    public List<PodcastListModel> GetAllSubscribed()
    {
        var entities = repository.GetAllByExpression(x => x.IsSubscribed);

        return entities
            .Select(mapper.MapToListModel)
            .ToList();
    }
}