using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;
using System;
using System.Linq;

namespace DotNetPodcasts.App.Web.Mappers;

public class PodcastMapper : IMapper<PodcastEntity, PodcastDetailModel, PodcastListModel>
{
    private readonly IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel> episodeMapper;

    public PodcastMapper(IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel> episodeMapper)
    {
        this.episodeMapper = episodeMapper;
    }

    public PodcastEntity MapToEntity(PodcastDetailModel model)
    {
        throw new NotImplementedException();
    }

    public PodcastDetailModel MapToDetailModel(PodcastEntity entity)
    {
        return new PodcastDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            AuthorName = entity.AuthorName,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            IsSubscribed = entity.IsSubscribed,
            Tags = entity.Tags?
                .Select(x => x.Name)
                .ToList(),
            Episodes = entity.Episodes?
                .Select(x => episodeMapper.MapToListModel(x))
                .ToList()
        };
    }

    public PodcastListModel MapToListModel(PodcastEntity model)
    {
        return new PodcastListModel
        {
            Id = model.Id,
            Name = model.Name,
            AuthorName = model.AuthorName,
            IsSubscribed = model.IsSubscribed,
            ImageUrl = model.ImageUrl
        };
    }
}