using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NewsFeedServices.Domain;
using NewsFeedServices.Interfaces.Services;
using NewsFeedServices.NewsFeedServices;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using Newtonsoft.Json;

namespace NewsFeedWebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedsController : ControllerBase
    {
        IFeedBackArticleService iFeedBackArticleService;
        readonly IFormatService iformatService;

        public NewsFeedsController(IFeedBackArticleService _iFeedBackArticleService, IFormatService _formatService)
        {
            iFeedBackArticleService = _iFeedBackArticleService;
            iformatService = _formatService;
        }

        // GET api/newsFeeds
        [HttpGet]
        public IEnumerable<FeedbackArticle> Get()
        {
            return iFeedBackArticleService.GetArticlesDetails();
        }

        // GET api/newsFeeds/5
        [HttpGet("{id}")]
        public IEnumerable<FeedbackArticle> Get(string id)
        {
            return iFeedBackArticleService.GetArticlesDetails(id);                
        }

        [HttpPost]
        public void Post(object jsonObject)
        {
            var result = iformatService.GetFormattedNewsFeed(jsonObject.ToString()).Article;
            iFeedBackArticleService.InsertArticle(result);
        }

        // PUT api/newsFeeds/5
        [HttpPut("{id}")]
        public void Put(string id, object jsonObject)
        {
            var result = iformatService.GetFormattedNewsFeed(jsonObject.ToString());
            iFeedBackArticleService.updateArticle(result);
        }

        // DELETE api/newsFeeds/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
