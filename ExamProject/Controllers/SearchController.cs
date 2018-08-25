using Art.Data;
using Art.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Art.App.Controllers
{
    public class SearchController : Controller
    {
        private ArtDbContext Context { get; set; }

        public SearchController(ArtDbContext context)
        {
            this.Context = context;
        }

        public List<Picture> PictureResults { get; set; }

        public IActionResult Results(string searchTag)
        {
            if (String.IsNullOrEmpty(searchTag))
            {
                return RedirectToPage("/Index");
            }

            var searchedPicturesByTag = this.Context
                .Pictures
                .Where(p => p.Tags.Any(t => t.Tag.TagName == searchTag))
                .ToList();

            var searchedPicturesByTitle = this.Context.Pictures
                .Where(p => p.Title.Contains(searchTag))
                .ToList();
            
            var result = searchedPicturesByTag
                .Concat(searchedPicturesByTitle)
                .Distinct()
                .ToList();

            this.PictureResults = result;
            
            ViewBag.Results = result.OrderByDescending(o => o.Likes).ToList();
            
            return View();
        }
    }
}