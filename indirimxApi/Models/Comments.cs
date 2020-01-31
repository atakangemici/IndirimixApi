using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Comments : BaseEntity
    {  
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }       

    }
}