namespace Art.App.Models
{
    public class ViewPictureProfileModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }
        
        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
