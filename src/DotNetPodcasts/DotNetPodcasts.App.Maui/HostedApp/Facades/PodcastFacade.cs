using DotNetPodcasts.App.Maui.HostedApp.Mappers;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;

namespace DotNetPodcasts.App.Maui.HostedApp.Facades;

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