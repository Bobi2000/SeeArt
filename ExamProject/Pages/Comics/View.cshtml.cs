using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Pages.Comics
{
    public class ViewModel : PageModel
    {
        public ViewModel(ArtDbContext context)
        {
            this.Context = context;
        }

        private ArtDbContext Context { get; set; }

        public IList<Comic> Comics { get; set; }

        public IList<string> Tags { get; set; }

        public void OnGet()
        {
            this.Comics = this.Context
                .Comics
                .Include(a => a.Tags)
                .ThenInclude(a => a.Tag)
                .OrderBy(a => a.UploadDate)
                .ToList();

            foreach (var comic in this.Comics)
            {
                comic.Cover = this.Context.Pictures.Find(comic.CoverId);
            }
            
        }
    }
}