using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Art.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UserPictures = new List<Picture>();
            this.FollowedUsers = new List<UserFollower>();
            this.Followers = new List<UserFollower>();
            this.LikedPictures = new List<UserLikedPicture>();
        }

        public string FullName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        public IList<Picture> UserPictures { get; set; }

        public IList<UserFollower> FollowedUsers { get; set; }

        public IList<UserFollower> Followers { get; set; }

        public IList<UserLikedPicture> LikedPictures { get; set; }
    }
}