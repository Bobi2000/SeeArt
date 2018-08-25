using Art.App.Models;
using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Pages.ViewImage
{
    public class ImageModel : PageModel
    {
        public ImageModel(ArtDbContext context)
        {
            this.Context = context;
        }

        public ViewPictureModel PictureModel { get; set; }

        public IList<Picture> RecommendedPictures { get; set; } = new List<Picture>();

        [BindProperty]
        public int PictureId { get; set; }

        private ArtDbContext Context { get; set; }

        public void OnGet(int id)
        {
            var picture = this.Context.Pictures.Find(id);

            this.PictureModel = new ViewPictureModel
            {
                Id = picture.Id,
                Title = picture.Title,
                Likes = picture.Likes,
                Url = picture.Url,
                UserId = picture.UserId,
                UserName = this.Context.Users.Find(picture.UserId).UserName,
            };

            this.RecommendedPictures = this.Context
                .Pictures
                .Where(a => a.UserId == picture.UserId && a.IsImage)
                .OrderBy(arg => Guid.NewGuid()).Take(4).ToList();

        }

        public IActionResult OnPostLike()
        {
            var currentLoggedInUser = User.Identity.Name;

            var currentUser = this.Context
                .Users
                .Where(u => u.UserName == currentLoggedInUser)
                .FirstOrDefault();

            var likedPicture = this.Context
                .Pictures
                .Where(a => a.Id == this.PictureId)
                .FirstOrDefault();

            var userLikedPicture = new UserLikedPicture
            {
                User = currentUser,
                UserId = currentUser.Id,
                Picture = likedPicture,
                PictureId = likedPicture.Id,
            };

            likedPicture.Likes++;

            this.Context.Pictures.Update(likedPicture);
            this.Context.UserLikedPictures.Add(userLikedPicture);
            this.Context.SaveChanges();

            return Redirect("/viewimage/image/" + this.PictureId);
        }

        public IActionResult OnPostUnLike()
        {
            var currentLoggedInUser = User.Identity.Name;

            var currentUser = this.Context
                .Users
                .Where(u => u.UserName == currentLoggedInUser)
                .FirstOrDefault();

            var likedPicture = this.Context
                .Pictures
                .Where(a => a.Id == this.PictureId)
                .FirstOrDefault();

            var userLikedPicture = this.Context
                .UserLikedPictures
                .Where(a => a.PictureId == likedPicture.Id && a.UserId == currentUser.Id)
                .FirstOrDefault();

            likedPicture.Likes--;

            this.Context.Pictures.Update(likedPicture);
            this.Context.UserLikedPictures.Remove(userLikedPicture);
            this.Context.SaveChanges();

            return Redirect("/viewimage/image/" + this.PictureId);
        }

        public IActionResult OnPostReport()
        {
            var picture = this.Context.Pictures.Find(this.PictureId);

            picture.IsReported = true;

            this.Context.Pictures.Update(picture);
            this.Context.SaveChangesAsync();

            return Redirect("/viewimage/image/" + this.PictureId);
        }

        public bool HasAlreadyLiked(int pictureId)
        {
            var currentLoggedInUser = this.Context
                .Users
                .Where(a => a.UserName == User.Identity.Name)
                .FirstOrDefault();

            var picturePage = this.Context
                .Pictures
                .Where(p => p.Id == pictureId)
                .FirstOrDefault();

            var isLiked = this.Context
                .UserLikedPictures
                .Where(a => a.UserId == currentLoggedInUser.Id && a.PictureId == picturePage.Id)
                .FirstOrDefault();

            if (isLiked == null)
            {
                return false;
            }

            return true;
        }

    }
}