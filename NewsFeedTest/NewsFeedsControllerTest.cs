using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsFeedServices.Interfaces.Services;
using NewsFeedWebApiServer.Controllers;

namespace NewsFeedTest
{
    [TestClass]
    public class NewsFeedsControllerTest
    {
        [TestMethod]
        public void NewsFeedsMethod1()
        {
            var mock = new Mock<IFeedBackArticleService>();
            var mock1 = new Mock<IFormatService>();
            //mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
            NewsFeedsController newsFeedsController = new NewsFeedsController(mock.Object, mock1.Object);
            var result = newsFeedsController.Get();
            Assert.IsNotNull(result);
        }
    }
}
