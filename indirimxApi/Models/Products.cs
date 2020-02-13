using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Products : BaseEntity
    {
        //Likse ve diğer alt tablolalar burada tanımlanıcak.
        public Users user { get; set; }
        public Images image { get; set; }
        //column name comment_id
        public Comments comment { get; set; }
        public Likes like { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string location { get; set; }
        public string store { get; set; }
        public int likes_count { get; set; }
        //public int like_count { get; set; }
        public int comments_count{ get; set; }
        public string description { get; set; }
        public bool is_active { get; set; }
        public int order { get; set; }

    }
}