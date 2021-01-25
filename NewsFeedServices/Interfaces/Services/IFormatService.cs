using NewsFeedServices.Domain;

namespace NewsFeedServices.Interfaces.Services
{
    public interface IFormatService
    {
        FeedbackArticle  GetFormattedNewsFeed(string newsfeed);
    }
}
