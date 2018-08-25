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
    public class ComicController : Controller
    {
        //private readonly IHostingEnvironment AppEnviroment;

        private ArtDbContext Context { get; set; }

        public ComicController(ArtDbContext context)
        {
            //this.AppEnviroment = appEnviroment;
            this.Context = context;
        }

        public IActionResult AddChapter(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public IActionResult AddPage(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public IActionResult UploadComic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadComic(IFormFile file, string title, string tags, string description)
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

            var path = "_Pictures\\" + username + "\\Comic";
            DirectoryInfo di = Directory.CreateDirectory(path);
            var pathToImages = path + "\\" + Guid.NewGuid() + fileExtension;

            using (var stream = new FileStream(pathToImages, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var picture = new Picture()
            {
                UploadDate = DateTime.Now,
                Url = pathToImages,
                UserName = username,
                UserId = userId,
                IsImage = false,
            };

            var keywords = tags
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var listOfTagsAll = this.Context.Tags;

            var listOfComicTags = new List<ComicTag>();

            var comic = new Comic
            {
                Title = title,
                Cover = picture,
                CoverId = picture.Id,
                Description = description,
                UploadDate = DateTime.Now,
                OwnerUsername = username
            };

            foreach (var tag in keywords)
            {
                var existsTag = listOfTagsAll.Where(a => a.TagName == tag).FirstOrDefault();

                if (existsTag == null)
                {
                    var newTag = new Tag
                    {
                        TagName = tag
                    };

                    var comicTag = new ComicTag
                    {
                        Comic = comic,
                        ComicId = comic.Id,
                        Tag = newTag,
                        TagId = newTag.Id
                    };

                    listOfComicTags.Add(comicTag);

                    this.Context.ComicTags.Add(comicTag);
                    this.Context.Tags.Add(newTag);
                }
                else
                {
                    var pictureTag = new ComicTag
                    {
                        Comic = comic,
                        ComicId = comic.Id,
                        Tag = existsTag,
                        TagId = existsTag.Id
                    };

                    listOfComicTags.Add(pictureTag);

                    this.Context.ComicTags.Add(pictureTag);
                }
            }

            //picture.Tags = listOfComicTags;
            comic.Tags = listOfComicTags;

            this.Context.Pictures.Add(picture);
            this.Context.Comics.Add(comic);
            await this.Context.SaveChangesAsync();

            return Redirect($"/comics/details/{picture.Id}");
        }

        [HttpPost]
        public async Task<IActionResult> AddChapter(IFormFile file, string title, int comicId)
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

            var path = "_Pictures\\" + username + "\\Comic";
            DirectoryInfo di = Directory.CreateDirectory(path);
            var pathToImages = path + "\\" + Guid.NewGuid() + fileExtension;

            using (var stream = new FileStream(pathToImages, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var picture = new Picture()
            {
                UploadDate = DateTime.Now,
                Url = pathToImages,
                UserName = username,
                UserId = userId,
                IsImage = false,
            };

            var chapter = new Chapter()
            {
                Title = title,
                ComicId = comicId,
                UploadDate = DateTime.Now
            };

            ViewData["chapter"] = chapter.Id;

            var chapterPicture = new ChapterPicture
            {
                Chapter = chapter,
                ChapterId = chapter.Id,
                Picture = picture,
                PictureId = picture.Id
            };

            chapter.Pictures.Add(chapterPicture);

            this.Context.Chapters.Add(chapter);
            this.Context.ChapterPictures.Add(chapterPicture);
            this.Context.Pictures.Add(picture);
            await this.Context.SaveChangesAsync();

            return Redirect("/Comic/AddPage/" + chapter.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddPage(IFormFile file, int chapterId)
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

            var path = "_Pictures\\" + username + "\\Comic";
            DirectoryInfo di = Directory.CreateDirectory(path);
            var pathToImages = path + "\\" + Guid.NewGuid() + fileExtension;

            using (var stream = new FileStream(pathToImages, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var picture = new Picture()
            {
                UploadDate = DateTime.Now,
                Url = pathToImages,
                UserName = username,
                UserId = userId,
                IsImage = false,
            };

            var chapter = this.Context.Chapters.Find(chapterId);

            var chapterPicture = new ChapterPicture
            {
                Chapter = chapter,
                ChapterId = chapter.Id,
                Picture = picture,
                PictureId = picture.Id
            };

            chapter.Pictures.Add(chapterPicture);

            this.Context.ChapterPictures.Add(chapterPicture);
            this.Context.Pictures.Add(picture);
            await this.Context.SaveChangesAsync();

            return Redirect("/Comic/AddPage/" + chapterId);
        }
    }
}