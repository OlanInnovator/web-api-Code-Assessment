using System;
namespace NewsFeedServices.Domain
{
    public class Article
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedDate { get; set; }
    }
}
