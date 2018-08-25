using Art.App.Controllers;
using Art.Data;
using Art.Test.Mock;
using Art.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace Art.Test
{
    [TestClass]
    public class ComicControllerTest
    {
        [TestMethod]
        public async Task UploadComic_ComicIsNotUploaded_WhenImageIsNotCorrect()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("links.txt");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);

                await controller.UploadComic(formFile, "Test", "Test", "Test");
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task UploadComic_ComicIsNotUploaded_WhenImageIsNull()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new ComicController(db);

                await controller.UploadComic(null, "Test", "Test", "Test");
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task UploadComic_ComicIsUploaded_WhenImageIsCorrectJpg()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("001.jpg");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.UploadComic(formFile, "Test", "Test", "Test");
                }
                catch { }
                
                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task UploadComic_ComicIsUploaded_WhenImageIsCorrectPng()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("002.png");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.UploadComic(formFile, "Test", "Test", "Test");
                }
                catch { }

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task AddChapter_ChapterIsNotUploaded_WhenImageIsNotCorrect()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("links.txt");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);

                await controller.AddChapter(formFile, "Test", 1);
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task AddChapter_ImageIsNotUploaded_WhenImageIsNull()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new ComicController(db);

                await controller.AddChapter(null, "Test", 1);
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task AddChapter_ChapterIsUploaded_WhenImageIsCorrectJpg()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("001.jpg");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.AddChapter(formFile, "Test", 0);
                }
                catch { }

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task UploadChapter_ChapterIsUploaded_WhenImageIsCorrectPng()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("002.png");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.AddChapter(formFile, "Test", 1);
                }
                catch { }

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task AddPage_PageIsNotUploaded_WhenImageIsNotCorrect()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("links.txt");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);

                await controller.AddPage(formFile, 1);
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task AddPage_PageIsNotUploaded_WhenImageIsNull()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new ComicController(db);

                await controller.AddPage(null, 1);
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task AddPage_PageIsUploaded_WhenImageIsCorrectJpg()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("001.jpg");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.AddPage(formFile, 0);
                }
                catch { }

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task UploadPage_PageIsUploaded_WhenImageIsCorrectPng()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("002.png");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ComicController(db);
                try
                {
                    await controller.AddPage(formFile, 1);
                }
                catch { }

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

    }
}
