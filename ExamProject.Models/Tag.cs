using System.Collections.Generic;

namespace Art.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Pictures = new List<PictureTag>();
            this.Comics = new List<ComicTag>();
        }

        public int Id { get; set; }

        public string TagName { get; set; }

        public IList<PictureTag> Pictures { get; set; }

        public IList<ComicTag> Comics { get; set; }
    }
}
