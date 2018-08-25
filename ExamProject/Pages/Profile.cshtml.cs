using Art.App.Models;
using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Pages
{
    public class ProfileModel : PageModel
    {
        public ProfileModel(ArtDbContext context)
        {
            this.Context = context;
        }

        public ArtDbContext Context { get; set; }

        public User UserPage { get; set; }

        public int FollowersCount { get; set; }

        public List<ViewPictureProfileModel> PictureModel { get; set; }

        public void OnGet(string username)
        {
            this.UserPage = this.Context
                .Users
                .Where(a => a.UserName == username)
                .FirstOrDefault();

            this.FollowersCount = this.Context
                                        .Followers
                                        .Where(a => a.FollowedId == this.UserPage.Id)
                                        .Count();

            this.PictureModel = this.Context
                .Pictures
                .Where(a => a.UserId == this.UserPage.Id && a.IsImage)
                .OrderByDescending(a => a.UploadDate)
                .Select(a => new ViewPictureProfileModel
                {
                    Id = a.Id,
                    UserId = this.UserPage.Id,
                    Likes = a.Likes,
                    Title = a.Title,
                    Url = a.Url,
                    UserName = a.UserName,
                }).ToList();
            

        }

        [BindProperty]
        public string UserName { get; set; }
        
        public IActionResult OnPostFollow()
        {
            var currentLoggedInUser = User.Identity.Name;

            var currentUser = this.Context
                .Users
                .Where(u => u.UserName == currentLoggedInUser)
                .FirstOrDefault();

            var followedUser = this.Context
                .Users
                .Where(u => u.UserName == this.UserName)
                .FirstOrDefault();
            
            var userFollower = new UserFollower
            {
                FollowedId = followedUser.Id,
                FollowedUser = followedUser,
                FollowerId = currentUser.Id,
                FollowerUser = currentUser,
            };

            currentUser.Followers.Add(userFollower);
            
            this.Context.SaveChangesAsync();

            return Redirect("/profile/" + this.UserName);
        }

        public IActionResult OnPostUnFollow()
        {
            var currentLoggedInUser = User.Identity.Name;

            var currentUser = this.Context
                .Users
                .Where(u => u.UserName == currentLoggedInUser)
                .FirstOrDefault();

            var followedUser = this.Context
                .Users
                .Where(u => u.UserName == this.UserName)
                .FirstOrDefault();

           var followed = this.Context
                .Followers
                .Where(a => a.FollowerId == currentUser.Id 
                        && a.FollowedId == followedUser.Id)
                .FirstOrDefault();

            this.Context.Followers.Remove(followed);

            this.Context.SaveChangesAsync();

            //return RedirectToPage("/profile/" + this.UserName);
            return Redirect("/profile/" + this.UserName);
        }

        public bool IsOwnUser(string username)
        {
            if (username == User.Identity.Name)
            {
                return true;
            }

            return false;
        }

        public bool HasAlreadySubscribed(string username)
        {
            var currentLoggedInUser = this.Context
                .Users
                .Where(a => a.UserName == User.Identity.Name)
                .FirstOrDefault();

            var userPage = this.Context
                .Users
                .Where(a => a.UserName == username)
                .FirstOrDefault();

            var isFollowed = this.Context
                .Followers
                .Where(a => a.FollowerId == currentLoggedInUser.Id && a.FollowedId == userPage.Id)
                .FirstOrDefault();

            if (isFollowed == null)
            {
                return false;
            }

            return true;
        }
    }
}