using Art.App.Controllers;
using Art.Data;
using Art.Models;
using Art.Tests.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Art.Test
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]
        public void Results_NoResults_WhenSearchStringIsNull()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new SearchController(db);

                string searchTag = null;

                RedirectToPageResult result = (RedirectToPageResult)controller.Results(searchTag) ;

                
                Assert.AreEqual(result.PageName, "/Index");
            }
        }

        [TestMethod]
        public async Task Results_Results_WhenSearchIsTitle()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new SearchController(db);

                var picture = new Picture
                {
                    Id = 1,
                    IsImage = true,
                    Likes = 10,
                    Title = "Test",
                    UploadDate = DateTime.Now,
                    Url = "//Test",
                    UserId = "test",
                    UserName = "test"
                };

                await db.Pictures.AddAsync(picture);

                await db.SaveChangesAsync();

                string searchTerm = "Test";

                controller.Results(searchTerm);

                Assert.AreEqual(1, controller.PictureResults.Count);
            }
        }

        [TestMethod]
        public async Task Results_Results_WhenSearchIsTag()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new SearchController(db);
                
                var picture = new Picture
                {
                    Id = 1,
                    IsImage = true,
                    Likes = 10,
                    Title = "Test",
                    UploadDate = DateTime.Now,
                    Url = "//Test",
                    UserId = "test",
                    UserName = "test"
                };
                
                var tag = new Tag()
                {
                    Id = 1,
                    TagName = "Tag",
                };

                var pictureTag = new PictureTag
                {
                    Picture = picture,
                    PictureId = picture.Id,
                    Tag = tag,
                    TagId = tag.Id
                };

                tag.Pictures.Add(pictureTag);
                picture.Tags.Add(pictureTag);

                await db.Pictures.AddAsync(picture);

                await db.SaveChangesAsync();

                string searchTerm = "Tag";

                controller.Results(searchTerm);

                Assert.AreEqual(1, controller.PictureResults.Count);
            }
        }
    }
}
