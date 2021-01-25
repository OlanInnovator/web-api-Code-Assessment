using System;
namespace NewsFeedServices.Domain
{
    public class FeedBack
    {
        public int Id { get; set; }
        public bool Islike { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        public string ArticleId { get; set; }
    }
}
