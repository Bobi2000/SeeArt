using Art.Data;
using Microsoft.AspNetCore.Mvc;

namespace Art.App.Controllers
{
    public class ProfileController : Controller
    {
        private ArtDbContext Context { get; set; }

        public ProfileController(ArtDbContext context)
        {
            this.Context = context;
        }
        
        public IActionResult List()
        {
            return View();
        }
    }
}