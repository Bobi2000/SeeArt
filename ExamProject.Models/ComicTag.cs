namespace Art.Models
{
    public class ComicTag
    {
        public int ComicId { get; set; }
        public Comic Comic { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}