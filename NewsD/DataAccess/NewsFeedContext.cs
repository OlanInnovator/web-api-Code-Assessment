using Microsoft.EntityFrameworkCore;
using NewsFeedDAL_EF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFeedDAL_EF.DataAccess
{
    public class NewsFeedContext : DbContext 
    {
        public NewsFeedContext(DbContextOptions options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<PresConUser> PresConUsers { get; set; }
    }
}
