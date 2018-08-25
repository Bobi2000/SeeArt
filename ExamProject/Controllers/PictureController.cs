using Art.App.Authorization;
using Art.App.Models;
using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private ArtDbContext Context { get; set; }
        
        public PictureController(ArtDbContext context)
        {
            this.Context = context;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        [BindProperty]
        public Picture Picture { get; set; }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Index");
            }
            
            var pictureToEdit = this.Context.Pictures
                .Include(a => a.Tags)
                .Where(b => b.Id == id)
                .FirstOrDefault();

            if (Authorized.IsAuthorizedUser(pictureToEdit.UserName, this.User.Identity.Name))
            {
                return RedirectToPage("/Index");
            }

            string tagsInString = "";

            foreach (var tag in pictureToEdit.Tags)
            {
                tagsInString += this.Context.Tags.Find(tag.TagId).TagName + " ";
            }

            tagsInString.Trim();

            var viewModel = new ViewEditPictureModel
            {
                Id = (int)id,
                Title = pictureToEdit.Title,
                Tags = tagsInString,
                UserId = pictureToEdit.UserId,
            };

            ViewBag.ViewModel = viewModel;

            return View();
        }

        public IActionResult Confirm()
        {
            var pictureToEdit = this.Context.Pictures.Include(a => a.Tags).Where(b => b.Id == this.Id).FirstOrDefault();

            if (Authorized.IsAuthorizedUser(pictureToEdit.UserName, this.User.Identity.Name))
            {
                return RedirectToPage("/Index");
            }

            pictureToEdit.Title = this.Title;

            var keywords = this.Tags
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var listOfTagsAll = this.Context.Tags;

            var listOfPictureTags = new List<PictureTag>();

            foreach (var tag in keywords)
            {
                int? tagId = 0;

                try
                {
                    tagId = this.Context.Tags.Where(a => a.TagName == tag).FirstOrDefault().Id;
                }
                catch { }

                if (pictureToEdit.Tags.Any(a => a.Tag.Id == tagId))
                {
                    continue;
                }

                var existsTag = listOfTagsAll.Where(a => a.TagName == tag).FirstOrDefault();

                if (existsTag == null)
                {
                    var newTag = new Tag
                    {
                        TagName = tag
                    };

                    var pictureTag = new PictureTag
                    {
                        Picture = pictureToEdit,
                        PictureId = pictureToEdit.Id,
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
                        Picture = pictureToEdit,
                        PictureId = pictureToEdit.Id,
                        Tag = existsTag,
                        TagId = existsTag.Id
                    };

                    listOfPictureTags.Add(pictureTag);

                    this.Context.PictureTag.Add(pictureTag);
                }
            }

            pictureToEdit.Tags = listOfPictureTags;

            this.Context.Pictures.Update(pictureToEdit);
            this.Context.SaveChanges();

            return Redirect($"/viewImage/image/{pictureToEdit.Id}");
        }

        public IActionResult Delete()
        {
            var b = this.Picture.UserId;

            var picture = this.Context.Pictures.Find(this.Picture.Id);
            var likes = this.Context.UserLikedPictures.Where(a => a.PictureId == picture.Id);

            this.Context.Pictures.Remove(picture);
            this.Context.UserLikedPictures.RemoveRange(likes);

            this.Context.SaveChanges();

            return Redirect($"/Index");
        }
    }
}