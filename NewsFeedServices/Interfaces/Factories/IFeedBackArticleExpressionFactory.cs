using NewsFeedServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NewsFeedServices.Interfaces.Factories
{
    public interface IFeedBackArticleExpressionFactory
    {
        Expression<Func<NewsFeedDAL_EF.Model.Article, bool>> Article(string _articleId);
        Expression<Func<NewsFeedDAL_EF.Model.FeedBack, bool>> FeedBacksInArticles(IEnumerable<Article> articlesByFeedbacks);
    }
}
