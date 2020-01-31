using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Products : BaseEntity
    {
        public Users user { get; set; }
        public ProductImages image { get; set; }
        public Comments comment { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string location { get; set; }
        public string store { get; set; }
        public int like { get; set; }
        public string description { get; set; }
        public bool is_active { get; set; }
        public int order { get; set; }

    }
}