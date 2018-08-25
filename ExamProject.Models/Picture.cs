using System;
using System.Collections.Generic;

namespace Art.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Likes = 0;
            this.IsImage = true;
            this.IsReported = false;
            this.Tags = new List<PictureTag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
        
        public int Likes { get; set; }

        public DateTime UploadDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public IList<PictureTag> Tags { get; set; }

        public bool IsImage { get; set; }

        public bool IsReported { get; set; }
    }
}