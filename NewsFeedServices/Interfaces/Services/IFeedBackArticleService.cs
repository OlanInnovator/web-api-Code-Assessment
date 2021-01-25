using NewsFeedServices.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedServices.Interfaces.Services
{
    public interface IFeedBackArticleService
    {
        void InsertArticle(Article article);

        void InsertFeedBack(FeedBack feedBack);

        IEnumerable<FeedbackArticle> GetArticlesDetails();

        IEnumerable<FeedbackArticle> MergeFeedBacksWithArticles(IEnumerable<Article> articles, IEnumerable<FeedBack> feedBacks);
        IEnumerable<FeedbackArticle> GetArticlesDetails(string id);
        void updateArticle(FeedbackArticle value);
    }
}
