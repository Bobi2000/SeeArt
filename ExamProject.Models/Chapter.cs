using System;
using System.Collections.Generic;

namespace Art.Models
{
    public class Chapter
    {
        public Chapter()
        {
            this.Pictures = new List<ChapterPicture>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int ComicId { get; set; }

        public DateTime UploadDate { get; set; }

        public IList<ChapterPicture> Pictures { get; set; }
    }
}