using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Deleted { get; set; }
    }
}