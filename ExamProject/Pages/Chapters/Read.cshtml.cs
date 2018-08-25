using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Art.App.Pages.Chapters
{
    public class ReadModel : PageModel
    {
        public ReadModel(ArtDbContext context)
        {
            this.Context = context;
        }

        public ArtDbContext Context { get; set; }

        public Chapter Chapter { get; set; }

        public void OnGet(int id)
        {
            this.Chapter = this.Context.Chapters
                .Include(a => a.Pictures)
                .ThenInclude(a => a.Picture)
                .Where(a => a.Id == id)
                .FirstOrDefault();
            

            var aa = 5;
        }
    }
}