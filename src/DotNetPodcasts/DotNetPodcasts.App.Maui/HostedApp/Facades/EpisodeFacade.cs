using DotNetPodcasts.App.Maui.HostedApp.Mappers;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;

namespace DotNetPodcasts.App.Maui.HostedApp.Facades;

public class EpisodeFacade : FacadeBase<EpisodeEntity, EpisodeDetailModel, EpisodeListModel>
{
    public EpisodeFacade(IRepository<EpisodeEntity> repository, IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel> mapper) 
        : base(repository, mapper)
    {
    }

    public List<EpisodeListModel> GetAllSavedForLater()
    {
        var entities = repository.GetAllByExpression(x => x.IsSaved);

        return entities
            .Select(mapper.MapToListModel)
            .ToList();
    }

    public void ToggleBookmark(int id)
    {
        var episode = repository.GetById(id, false);
        episode.IsSaved = !episode.IsSaved;

        repository.Save(episode, false);
    }
}