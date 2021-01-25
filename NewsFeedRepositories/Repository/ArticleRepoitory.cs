using Microsoft.EntityFrameworkCore;
using NewsFeedDAL_EF.DataAccess;
using NewsFeedDAL_EF.Model;
using NewsFeedRepositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsFeedRepositories.Repository
{
    public class ArticleRepoitory : IArticleRepoitory , IDisposable
    {
        private NewsFeedContext newsFeedContext;

        public ArticleRepoitory(NewsFeedContext _newsFeedContext)
        {
            newsFeedContext = _newsFeedContext;
        }

        public void DeleteArticle(int articleID)
        {
            var articleToRemove = newsFeedContext.Articles.Find(articleID);
            newsFeedContext.Articles.Remove(articleToRemove);
        }

        public Article GetArticleByID(int articleId)
        {
            return newsFeedContext.Articles.Find(articleId);           
        }

        public IEnumerable<Article> GetArticles()
        {
            return newsFeedContext.Articles.ToList();
        }

        public void InsertArticle(Article article)
        {
            
            newsFeedContext.Articles.Add(article);
            newsFeedContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Articles ON");
            Save();
            newsFeedContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Articles OFF");
       
        }

        public void Save()
        {
            newsFeedContext.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            newsFeedContext.Articles.Update(article);
            Save();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    newsFeedContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ArticleRepoitory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
