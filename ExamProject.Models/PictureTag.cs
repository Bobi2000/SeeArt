namespace Art.Models
{
    public class PictureTag
    {
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
