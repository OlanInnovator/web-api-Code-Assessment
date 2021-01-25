using NewsFeedDAL_EF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedRepositories.Interface
{
    public interface IFeedsBackRepoitory : IDisposable
    {
        IEnumerable<FeedBack> GetFeedsBacks();
        void InsertFeedBack(FeedBack feedBack);
        void Save();
    }
}
