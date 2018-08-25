using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Pages.Followers
{
    public class ListModel : PageModel
    {
        public ListModel(ArtDbContext context)
        {
            this.Context = context;
        }

        private ArtDbContext Context { get; set; }

        public IList<User> Followers { get; set; } = new List<User>();

        public IActionResult OnGet(string username)
        {
            if (username == null)
            {
                return RedirectToPage("/Index");
            }

            var user = this.Context.Users.Where(u => u.UserName == username).Include(u => u.Followers).FirstOrDefault();

            var followers = this.Context.Followers.Include(a => a.FollowedUser).Include(a => a.FollowerUser).ToList();

            foreach (var follower in user.FollowedUsers)
            {
                this.Followers.Add(follower.FollowerUser);
            }
            
            return Page();
        }
    }
}