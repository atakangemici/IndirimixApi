using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime create_date { get; set; }
        public bool deleted { get; set; }
    }
}