using System.Collections.Generic;

namespace DotNetPodcasts.App.Web.Models;

public class PodcastDetailModel : ModelBase, IDetailModel
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSubscribed { get; set; }
    public string Description { get; set; }
    public IList<string> Tags { get; set; } = new List<string>();
    public IList<EpisodeListModel> Episodes { get; set; } = new List<EpisodeListModel>();
}