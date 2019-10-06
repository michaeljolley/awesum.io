using System;
using System.Collections.Generic;
using System.Text;

namespace AwesumIO.Core.Common
{
    public class UserDetail
    {
        public string FullName { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int FollowersCount { get; set; }
        public string Description { get; set; }
        public int StatusesCount { get; set; }
        public int FriendsCount { get; set; }
        public int FavouritesCount { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
