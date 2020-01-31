using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class ProductImages : BaseEntity
    {
        public string image { get; set; }
        public bool is_active { get; set; }
        public int order { get; set; }

    }
}