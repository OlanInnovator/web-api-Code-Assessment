using NewsFeedDAL_EF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedRepositories.Interface
{
    public interface IArticleRepoitory : IDisposable
    {
        IEnumerable<Article> GetArticles();
        Article GetArticleByID(int articleId);
        void InsertArticle(Article article);
        void DeleteArticle(int ArticleID);
        void UpdateArticle(Article article);
        void Save();
    }
}
