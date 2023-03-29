using DotNetPodcasts.App.Web.Mappers;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;

namespace DotNetPodcasts.App.Web.Facades;

public class PodcastFacade : FacadeBase<PodcastEntity, PodcastDetailModel, PodcastListModel>
{
    public PodcastFacade(IRepository<PodcastEntity> repository, IMapper<PodcastEntity, PodcastDetailModel, PodcastListModel> mapper)
        : base(repository, mapper)
    {
    }
}