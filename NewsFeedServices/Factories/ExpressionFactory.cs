using NewsFeedDAL_EF.Model;
using NewsFeedServices.Domain;
using NewsFeedServices.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Article = NewsFeedServices.Domain.Article;

namespace NewsFeedServices.Factories
{
    public class ExpressionFactory : IFeedBackArticleExpressionFactory
    {
        public Expression<Func<NewsFeedDAL_EF.Model.Article, bool>> Article(string _articleId) => article => article.Id.ToString() == _articleId;

        public Expression<Func<NewsFeedDAL_EF.Model.FeedBack, bool>> FeedBacksInArticles(IEnumerable<Article> articlesByFeedback)
            => feedBack => articlesByFeedback.Select(article => article.Id).Contains(feedBack.ArticleId.ToString());

    }
}
