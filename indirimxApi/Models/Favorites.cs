using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Favorites : BaseEntity
    {   
       
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public virtual Products Product { get; set; }

    }
}