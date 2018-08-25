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
    public class ImageControllerTest
    {
        [TestMethod]
        public async Task UploadImage_ImageIsNotUploaded_WhenImageIsNotCorrect()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("links.txt");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ImageController(db);

                await controller.UploadImage(formFile, "Test", "Test");
                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

        [TestMethod]
        public async Task UploadImage_ImageIsUploaded_WhenImageIsCorrectJpg()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("001.jpg");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ImageController(db);

                try
                {
                    await controller.UploadImage(formFile, "Test", "Test");
                }
                catch { }


                var a = controller.ModelState.ErrorCount;

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task UploadImage_ImageIsUploaded_WhenImageIsCorrectPng()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var physicalFile = new FileInfo("002.png");
                var formFile = physicalFile.AsMockIFormFile();

                var controller = new ImageController(db);

                try
                {
                    await controller.UploadImage(formFile, "Test", "Test");
                }
                catch { }


                var a = controller.ModelState.ErrorCount;

                Assert.AreEqual(controller.ModelState.ErrorCount, 0);
            }
        }

        [TestMethod]
        public async Task UploadImage_ImageIsNotUploaded_WhenImageIsNull()
        {
            using (var db = new ArtDbContext(TestingDbContextOptions.TestDbContextOptions()))
            {
                var controller = new ImageController(db);

                try
                {
                    await controller.UploadImage(null, "Test", "Test");
                }
                catch { }


                var a = controller.ModelState.ErrorCount;

                Assert.AreEqual(controller.ModelState.ErrorCount, 1);
            }
        }

    }
}
