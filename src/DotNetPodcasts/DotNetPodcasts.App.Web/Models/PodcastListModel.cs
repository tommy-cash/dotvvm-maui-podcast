using System;

namespace DotNetPodcasts.App.Web.Models;

public class PodcastListModel : ModelBase
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSubscribed { get; set; }
}