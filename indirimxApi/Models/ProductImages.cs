using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class ProductImages : BaseEntity
    {

        public int ProductId { get; set; }
        public string Image { get; set; }   
        public bool IsConfirm { get; set; }
        public int Order { get; set; }
       
    }
}