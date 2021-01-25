using NewsFeedDAL_EF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedRepositories.Interface
{
    public interface IPresConUsersRepoitory : IDisposable
    {
        PresConUser GetPresConUserByProfile(PresConUser presConUser);
    }
}
