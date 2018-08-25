using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Pages
{
    public class LikedPicturesModel : PageModel
    {
        public LikedPicturesModel(ArtDbContext context)
        {
            this.Context = context;
        }

        public ArtDbContext Context { get; set; }

        public IList<Picture> LikedPictures { get; set; } = new List<Picture>();

        public IActionResult OnGet(string username)
        {
           var user = this.Context
                .Users
                .Where(a => a.UserName == username)
                .Include(a => a.LikedPictures)
                .FirstOrDefault();

            var likedPictures = this.Context
                .UserLikedPictures
                .Where(a => a.UserId == user.Id)
                .Include(a => a.Picture)
                .ToList();

            if (user == null)
            {
                return RedirectToPage("/Index");
            }

            foreach (var pic in user.LikedPictures)
            {
                this.LikedPictures.Add(pic.Picture);
            }
            

            return Page();
        }
    }
}