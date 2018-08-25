using System;
using System.Collections.Generic;

namespace Art.Models
{
    public class Comic
    {
        public Comic()
        {
            this.Tags = new List<ComicTag>();
            this.Chapters = new List<Chapter>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Picture Cover { get; set; }

        public int CoverId { get; set; }

        public DateTime UploadDate { get; set; }

        public IList<ComicTag> Tags { get; set; }

        public IList<Chapter> Chapters { get; set; }

        public string OwnerUsername { get; set; }
    }
}
