using Art.App.Controllers;
using Art.Data;
using Art.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Art.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                //var comicController = new ComicController(db);

                

                Assert.AreEqual(0, 0);
            }


        }
    }
}
