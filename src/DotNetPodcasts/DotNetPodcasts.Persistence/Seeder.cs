using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;

namespace DotNetPodcasts.Persistence;

public class Seeder
{
    private readonly IRepository<PodcastEntity> podcastRepository;
    private readonly IRepository<EpisodeEntity> episodeRepository;
    private readonly IRepository<TagEntity> tagRepository;

    public readonly int PodcastsToGenerate = 7;
    public readonly int EpisodesToGeneratePerPodcast = 5;
    public readonly int TagsToGenerate = 12;
    public readonly int MaxTagsPerPodcast = 4;

    public Seeder(IRepository<PodcastEntity> podcastRepository, IRepository<EpisodeEntity> episodeRepository, IRepository<TagEntity> tagRepository)
    {
        this.podcastRepository = podcastRepository;
        this.episodeRepository = episodeRepository;
        this.tagRepository = tagRepository;
    }

    public void SeedPodcasts()
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

        for (int i = 0; i < PodcastsToGenerate; i++)
        {
            var randomTags = tags.Take(random.Next(1, MaxTagsPerPodcast));

            var newItem = new PodcastEntity
            {
                Name = ".future",
                AuthorName = "Microsoft / Gimlet Creative",
                Description =
                    "The future isn’t random. It’s the result of the choices that we make now. We’ll be talking about technologies and industries that will define the next decade and beyond. Join our host Cristina Quinn, a science and technology reporter, as she dives into everything from Minecraft to cyber warfare. You can wait for the future to happen to you or engage with it right now and ahead of the curve on .future— a branded podcast from Microsoft, produced in partnership with Gimlet Creative.",
                Tags = randomTags.ToList()
            };
            var id = podcastRepository.Save(newItem);

            for (int j = 0; j < EpisodesToGeneratePerPodcast; j++)
            {
                episodeRepository.Save(GenerateEpisode(id));
            }
        }
    }

    public EpisodeEntity GenerateEpisode(int podcastId)
    {
        return new EpisodeEntity
        {
            PodcastId = podcastId,
            Name = "Work in the .future",
            Description =
                "In the final episode of this season of .future, we hear how our jobs continue to evolve in the modern workplace. Many of us still spend 40 plus hours in a physical office, but the internet and new digital communication tools  are changing how we collaborate and communicate. This story brings you voices that explore work philosophies of the past, job practices of the present, and the digital office spaces of the future.",
            TotalMinutes = 21,
            PublishedDate = new DateTime(2017, 8, 9)
        };
    }
}