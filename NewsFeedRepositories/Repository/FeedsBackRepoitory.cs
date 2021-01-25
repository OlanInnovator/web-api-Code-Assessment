using NewsFeedDAL_EF.DataAccess;
using NewsFeedDAL_EF.Model;
using NewsFeedRepositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsFeedRepositories.Repository
{
    public class FeedsBackRepoitory : IFeedsBackRepoitory, IDisposable
    {
        private NewsFeedContext newsFeedContext;

        public FeedsBackRepoitory(NewsFeedContext _newsFeedContext)
        {
            newsFeedContext = _newsFeedContext;
        }

        public IEnumerable<FeedBack> GetFeedsBacks()
        {
            return newsFeedContext.FeedBacks.ToList();
        }
        
        public void Save()
        {
            newsFeedContext.SaveChanges();
        }

        public void InsertFeedBack(FeedBack feedBack)
        {
            newsFeedContext.FeedBacks.Add(feedBack);
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
        // ~FeedsBackRepoitory() {
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
