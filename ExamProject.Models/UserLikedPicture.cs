namespace Art.Models
{
    public class UserLikedPicture
    {
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
