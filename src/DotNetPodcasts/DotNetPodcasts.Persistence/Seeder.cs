using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace DotNetPodcasts.Persistence;

public class Seeder
{
    private readonly IRepository<PodcastEntity> podcastRepository;
    private readonly IRepository<EpisodeEntity> episodeRepository;
    private readonly IRepository<TagEntity> tagRepository;

    private readonly string[] Feeds = {
        "http://feeds.codenewbie.org/cnpodcast.xml",
        "https://msdevshow.libsyn.com/rss",
        "https://feeds.simplecast.com/gvtxUiIf",
        "http://feeds.gimletcreative.com/dotfuture"
    };

    public readonly int TagsToGenerate = 12;
    public readonly int MaxTagsPerPodcast = 4;
    public readonly int MaxEpisodesPerPodcast = 10;

    public Seeder(
        IRepository<PodcastEntity> podcastRepository, 
        IRepository<EpisodeEntity> episodeRepository, 
        IRepository<TagEntity> tagRepository)
    {
        this.podcastRepository = podcastRepository;
        this.episodeRepository = episodeRepository;
        this.tagRepository = tagRepository;
    }

    public async Task SeedPodcasts()
    {
        var random = new Random();

        podcastRepository.DeleteAll();
        episodeRepository.DeleteAll();
        tagRepository.DeleteAll();

        var tags = new List<TagEntity>();

        for (int i = 0; i < TagsToGenerate; i++)
        {
            var tag = new TagEntity
            {
                Name = $"Stored sample tag{i}"
            };
            var tagId = tagRepository.Save(tag);

            tags.Add(tag);
        }

        foreach (var feed in Feeds)
        {
            var randomTags = tags.Take(random.Next(1, MaxTagsPerPodcast));
            using var httpClient = new HttpClient();
            var xmlSerializer = new XmlSerializer(typeof(Rss));

            await using var feedContent = await httpClient.GetStreamAsync(feed);
            var rss = await Task.Run(() =>
            {
                return (Rss) xmlSerializer.Deserialize(feedContent)!;
            });

            if (rss == null)
            {
                return;
            }

            var newItem = new PodcastEntity
            {

                Name = rss.Channel.Title,
                ImageUrl = rss.Channel.Image?.Url ?? rss.Channel.Image2?.Href ?? "https://picsum.photos/seed/podcast-card/200/300",
                AuthorName = rss.Channel.Author ?? string.Empty,
                Description = rss.Channel.Description,
                Tags = randomTags.ToList()
            };
            var id = podcastRepository.Save(newItem);

            foreach (var episode in rss.Channel.Item.Take(MaxEpisodesPerPodcast))
            {
                episodeRepository.Save(GenerateEpisode(id,
                    episode.Title,
                    episode.Summary ?? episode.Description ?? string.Empty,
                    episode.PubDate != null ? DateTime.Parse(episode.PubDate) : DateTime.MinValue,
                    episode.Enclosure?.Url 
                        ?? "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                    ConvertStringyfiedDurationToSeconds(episode.Duration)));
            }
        }
    }

    public EpisodeEntity GenerateEpisode(int podcastId, string name, string description, DateTime publishedDate, string mediaUrl, int totalMinutes)
    { 
        return new EpisodeEntity
        {
            PodcastId = podcastId,
            Name = name,
            Description = description,
            PublishedDate = publishedDate,
            MediaUrl = mediaUrl,
            TotalMinutes = totalMinutes
        };
    }

    private int ConvertStringyfiedDurationToSeconds(string? duration)
    {
        if (string.IsNullOrEmpty(duration)
            || !TimeSpan.TryParseExact(duration, new[] {@"hh\:mm\:ss", @"mm\:ss"}, null, out var timeSpanDuration))
        {
            return 0;
        }

        return (int)timeSpanDuration.TotalSeconds;
    }
}