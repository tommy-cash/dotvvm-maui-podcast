using DotNetPodcasts.App.Maui.HostedApp.Extensions;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.App.Maui.HostedApp.Mappers;

public class EpisodeMapper : IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel>
{
    public EpisodeEntity MapToEntity(EpisodeDetailModel model)
    {
        throw new System.NotImplementedException();
    }

    public EpisodeDetailModel MapToDetailModel(EpisodeEntity entity)
    {
        return new EpisodeDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            PublishedDate = entity.PublishedDate,
            IsSaved = entity.IsSaved,
            MediaUrl = entity.MediaUrl,
            PodcastId = entity.PodcastId
        };
    }

    public EpisodeListModel MapToListModel(EpisodeEntity entity)
    {
        return new EpisodeListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            PublishedDate = entity.PublishedDate,
            IsSaved = entity.IsSaved,
            MediaUrl = entity.MediaUrl,
            Duration = TimeSpan.FromSeconds(entity.TotalMinutes).ToDateTime()
        };
    }
}