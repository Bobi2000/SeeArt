using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        public AdminModel(ArtDbContext context)
        {
            this.Context = context;
        }

        private ArtDbContext Context { get; set; }

        public IList<Picture> ReportedPictures { get; set; }

        [BindProperty]
        public int PictureId { get; set; }

        public void OnGet()
        {
            this.ReportedPictures = this.Context.Pictures.Where(a => a.IsReported == true).ToList();
        }

        public IActionResult OnPostDelete()
        {
            var picture = this.Context.Pictures.Find(this.PictureId);

            this.Context.Pictures.Remove(picture);
            this.Context.SaveChanges();

            return Redirect("/admin/list");
        }

        public IActionResult OnPostApprove()
        {
            var picture = this.Context.Pictures.Find(this.PictureId);

            picture.IsReported = false;

            this.Context.Pictures.Update(picture);
            this.Context.SaveChanges();

            return Redirect("/admin/list");
        }
    }
}