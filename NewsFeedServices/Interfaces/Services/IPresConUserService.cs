using NewsFeedServices.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedServices.Interfaces.Services
{
    public interface IPresConUserService
    {
        PresConUser GetPresConUserByProfile(PresConUser presConUser);
    }
}
