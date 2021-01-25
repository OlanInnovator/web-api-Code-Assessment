using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedServices.Domain
{
    public class FeedbackArticle
    {
        public Int32 ArticleDetailId  { get; set; }
    public Article Article { get; set; }

        public IEnumerable<FeedBack> FeedBacks { get; set; }
    }
}
