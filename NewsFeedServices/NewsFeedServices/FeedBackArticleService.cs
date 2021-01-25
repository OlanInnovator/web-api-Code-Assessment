using NewsFeedRepositories.Interface;
using NewsFeedServices.Interfaces.Services;
using NewsFeedServices.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using NewsFeedServices.Interfaces.Factories;
using System.Linq;
using NewsFeedDAL_EF.Model;
using FeedBack = NewsFeedServices.Domain.FeedBack;

namespace NewsFeedServices.NewsFeedServices
{
    public class FeedBackArticleService : IFeedBackArticleService
    {
        private IArticleRepoitory articleRepository;
        private IFeedsBackRepoitory feedsBackRepoitory;
        private IFeedBackArticleExpressionFactory feedBackArticleExpressionFactory;

        public FeedBackArticleService(IArticleRepoitory _articleRepository, IFeedsBackRepoitory _feedsBackRepoitory,
            IFeedBackArticleExpressionFactory _feedBackArticleExpressionFactory)
        {
            articleRepository = _articleRepository;
            feedsBackRepoitory = _feedsBackRepoitory;
            feedBackArticleExpressionFactory = _feedBackArticleExpressionFactory;
        }

        public IEnumerable<FeedbackArticle> GetArticlesDetails()
        {
            try
            {
                var feedBacks = feedsBackRepoitory.GetFeedsBacks().ToList().Select(Map);
                var articles = articleRepository.GetArticles().ToList().Select(Map);
                return MergeFeedBacksWithArticles(articles, feedBacks);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<FeedbackArticle> GetArticlesDetails(string id)
        {
            var feedBacks = feedsBackRepoitory.GetFeedsBacks().ToList().Select(Map);
            var articles = articleRepository.GetArticles().ToList().Select(Map);

            return MergeFeedBacksWithArticles(articles, feedBacks).Where(f => f.Article.Id == id)
                .OrderByDescending(newsFeeds => newsFeeds.Article.UpdatedDate);
        }
        public void updateArticle(FeedbackArticle value)
        {
            articleRepository.UpdateArticle(MapTo(value.Article));
        }

        public void InsertArticle(Domain.Article _articlee)
        {            
            articleRepository.InsertArticle(MapTo(_articlee));
        }

        public void InsertFeedBack(Domain.FeedBack feedBack)
        {
            feedsBackRepoitory.InsertFeedBack(MapToo(feedBack));
        }
               
        public IEnumerable<FeedbackArticle> MergeFeedBacksWithArticles(IEnumerable<Domain.Article> articles, IEnumerable<Domain.FeedBack> feedBacks)
        {
            var _feedBacksByArticleId = feedBacks
                .GroupBy(feedBack => feedBack.ArticleId)
                .ToDictionary(p => p.Key, p => p.ToList());

            var feedbackArticles = articles.Select(article => new FeedbackArticle()
            {
                Article = article,
                FeedBacks = _feedBacksByArticleId.Keys.Contains(article.Id) ? 
                _feedBacksByArticleId[article.Id] : new List<FeedBack>()
            });

            return feedbackArticles;
        }

        private NewsFeedDAL_EF.Model.FeedBack MapToo(Domain.FeedBack arg)
        {
            return new NewsFeedDAL_EF.Model.FeedBack()
            {
                Id = arg.Id,
                Islike = arg.Islike,
                Comment = arg.Comment,
                UserId = arg.UserId,
                ArticleId = Convert.ToInt32(arg.ArticleId)
            };
        }

        private NewsFeedDAL_EF.Model.Article MapTo(Domain.Article arg)
        {
            return new NewsFeedDAL_EF.Model.Article()
            {
                Id = Convert.ToInt32(arg.Id),
                Title = arg.Title,
                Body = arg.Body,
                ImageUrl = arg.ImageUrl
            };
        }

        private Domain.Article Map(NewsFeedDAL_EF.Model.Article arg)
        {
            return new Domain.Article()
            {
                Id = arg.Id.ToString(),
                Title = arg.Title,
                Body = arg.Body,
                ImageUrl = arg.ImageUrl,
                CreatedDate = arg.CreatedDate,
                UpdatedDate = arg.UpdatedDate.ToString("dddd, dd MMMM yyyy HH:mm:ss")
            };
        }

        private Domain.FeedBack Map(NewsFeedDAL_EF.Model.FeedBack arg)
        {
            return new Domain.FeedBack()
            {
                Id = arg.Id,
                Islike = arg.Islike,
                Comment = arg.Comment,
                CreatedDate = arg.CreatedDate,
                UserId = arg.UserId,
                ArticleId = arg.ArticleId.ToString()
            };
        }

    }
}
