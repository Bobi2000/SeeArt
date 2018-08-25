using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art.App.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(ArtDbContext context, IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.Context = context;
        }

        public IServiceProvider ServiceProvider { get; set; }

        private ArtDbContext Context { get; set; }

        public IList<Picture> TopDailyPictures { get; set; }

        public IList<Picture> FollowedUsersPictures { get; set; } = new List<Picture>();

        public void OnGet()
        {
            //await this.CreateRoles(this.ServiceProvider);

            this.TopDailyPictures = this.Context
                 .Pictures
                 .Where(p => p.IsImage)
                 .OrderByDescending(p => p.UploadDate)
                 .ToList();

            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var userName = this.User.Identity.Name;
                var user = this.Context
                    .Users
                    .Include(a => a.FollowedUsers)
                    .Where(u => u.UserName == userName)
                    .FirstOrDefault();

                var userFollowers = this.Context
                    .Followers
                    .Where(f => f.FollowerId == user.Id)
                    .ToList();

                foreach (var currentUser in userFollowers)
                {
                    var currentFollowedUser = this.Context.Users.Where(u => u.Id == currentUser.FollowedId).FirstOrDefault();

                    foreach (var pic in currentFollowedUser.UserPictures)
                    {
                        if (pic.IsImage)
                        {
                            this.FollowedUsersPictures.Add(pic);
                        }
                    }
                }

            }
        }

        public void OnGetNewest()
        {
            this.TopDailyPictures = this.Context
                 .Pictures
                 .Where(p => p.IsImage)
                 .OrderByDescending(p => p.UploadDate)
                 .ToList();
        }

        public void OnGetDaily()
        {
            this.TopDailyPictures = this.Context
                 .Pictures
                 .Where(p => p.UploadDate.Day == DateTime.Now.Day && p.IsImage)
                 .OrderByDescending(p => p.Likes)
                 .ToList();
        }

        public void OnGetPopularAllTime()
        {
            this.TopDailyPictures = this.Context
                .Pictures
                .Where(p => p.IsImage)
                .OrderByDescending(p => p.Likes)
                .ToList();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new User
            {
                UserName = "Admin",
                Email = "Admin@abv.bg",
                FullName = "Admin",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "Admin123";
            var _user = await UserManager.FindByEmailAsync("Admin@abv.bg");

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}