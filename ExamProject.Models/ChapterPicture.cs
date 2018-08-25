namespace Art.Models
{
    public class ChapterPicture
    {
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}