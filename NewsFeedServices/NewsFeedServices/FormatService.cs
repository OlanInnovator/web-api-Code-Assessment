using NewsFeedServices.Domain;
using NewsFeedServices.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedServices.NewsFeedServices
{
    public class FormatService : IFormatService
    {
        public FeedbackArticle GetFormattedNewsFeed(string newsfeed)
        {
            try
            {
                return JsonConvert.DeserializeObject<FeedbackArticle>(newsfeed);
            }
            catch(Exception ex)
            {
                return new FeedbackArticle()
                {
                    ArticleDetailId = -1
                };
            }
            
        }

    }
}
