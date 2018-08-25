using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Art.App.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        //private readonly IHostingEnvironment AppEnviroment;

        private ArtDbContext Context { get; set; }

        public ImageController(ArtDbContext context)
        {
        //    this.AppEnviroment = appEnviroment;
            this.Context = context;
        }

        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, string title, string tags)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("File", "File not selected!");
                return View();
            }
            
            var fileExtension = file.FileName.Substring(file.FileName.Length - Math.Min(4, file.FileName.Length));

            if (fileExtension != ".jpg" && fileExtension != ".png")
            {
                ModelState.AddModelError("File", "File not in the right format!");
                return View();
            }

            var username = this.ControllerContext.HttpContext.User.Identity.Name;

            var path = "_Pictures\\" + username;
            DirectoryInfo di = Directory.CreateDirectory(path);
            var pathToImages = path + "\\" + Guid.NewGuid() + fileExtension;

            using (var stream = new FileStream(pathToImages, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var picture = new Picture()
            {
                Title = title,
                UploadDate = DateTime.Now,
                Url = pathToImages,
                UserName = username,
                UserId = userId,
            };

            var keywords = tags
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var listOfTagsAll = this.Context.Tags;

            var listOfPictureTags = new List<PictureTag>();
            
            foreach (var tag in keywords)
            {
                var existsTag = listOfTagsAll.Where(a => a.TagName == tag).FirstOrDefault();
                
                if (existsTag == null)
                {
                    var newTag = new Tag
                    {
                        TagName = tag
                    };

                    var pictureTag = new PictureTag
                    {
                        Picture = picture,
                        PictureId = picture.Id,
                        Tag = newTag,
                        TagId = newTag.Id
                    };

                    listOfPictureTags.Add(pictureTag);

                    this.Context.PictureTag.Add(pictureTag);
                    this.Context.Tags.Add(newTag);
                }
                else
                {
                    var pictureTag = new PictureTag
                    {
                        Picture = picture,
                        PictureId = picture.Id,
                        Tag = existsTag,
                        TagId = existsTag.Id
                    };

                    listOfPictureTags.Add(pictureTag);

                    this.Context.PictureTag.Add(pictureTag);
                }
            }

            picture.Tags = listOfPictureTags;

            this.Context.Pictures.Add(picture);
            await this.Context.SaveChangesAsync();

            return Redirect($"/viewImage/image/{picture.Id}");
        }
    }
}