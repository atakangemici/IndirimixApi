using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Favorites : BaseEntity
    {
        public int id { get; set; }
        public Products product { get; set; }

    }
}