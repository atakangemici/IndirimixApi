using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Likes : BaseEntity
    {
        public int user_id { get; set; }
        public string like { get; set; }
        public int product_id { get; set; }

    }
}