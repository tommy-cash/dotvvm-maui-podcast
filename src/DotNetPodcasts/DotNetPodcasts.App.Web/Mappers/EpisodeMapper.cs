using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.App.Web.Mappers;

public class EpisodeMapper : IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel>
{
    public EpisodeEntity MapToEntity(EpisodeDetailModel model)
    {
        throw new System.NotImplementedException();
    }

    public EpisodeDetailModel MapToDetailModel(EpisodeEntity entity)
    {
        throw new System.NotImplementedException();
    }

    public EpisodeListModel MapToListModel(EpisodeEntity model)
    {
        return new EpisodeListModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            PublishedDate = model.PublishedDate,
            IsSaved = model.IsSaved,
            MediaUrl = model.MediaUrl,
            TotalMinutes = model.TotalMinutes  
        };
    }
}