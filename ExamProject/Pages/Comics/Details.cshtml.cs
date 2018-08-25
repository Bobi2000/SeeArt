using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Art.App.Pages.Comics
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(ArtDbContext context)
        {
            this.Context = context;
        }

        private ArtDbContext Context { get; set; }

        public Comic Comic { get; set; }

        public IList<Chapter> Chapters { get; set; }

        public int Year { get; set; }

        public string Tags { get; set; }

        public void OnGet(int id)
        {
            this.Comic = this.Context.Comics.Include(a => a.Tags).ThenInclude(a => a.Tag).Where(a => a.Id == id).FirstOrDefault();

            this.Comic.Cover = this.Context.Pictures.Find(this.Comic.CoverId);
            var myCal = new GregorianCalendar();
            this.Year = myCal.GetYear(this.Comic.UploadDate);

            this.Tags = string.Join(", ", this.Comic.Tags.Select(a => a.Tag.TagName));

            this.Chapters = this.Context.Chapters.Where(a => a.ComicId == this.Comic.Id).ToList();
        }
        
    }
}