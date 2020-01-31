using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Comments : BaseEntity
    {
        public int user_id { get; set; }
        public string comment { get; set; }
        public int product_id { get; set; }

    }
}