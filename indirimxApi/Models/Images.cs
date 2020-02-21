using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Images : BaseEntity
    {

        [Column("image")]
        public string Image { get; set; }

        [Column("product_id")]
        public Products Product { get; set; }     

    }
}