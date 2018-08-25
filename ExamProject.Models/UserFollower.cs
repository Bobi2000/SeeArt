namespace Art.Models
{
    public class UserFollower
    {
        public string FollowedId { get; set; }
        public User FollowedUser { get; set; }

        public string FollowerId { get; set; }
        public User FollowerUser { get; set; }
    }
}
