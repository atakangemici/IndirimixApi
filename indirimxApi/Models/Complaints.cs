using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Complaints : BaseEntity
    {
        [Column("user_id")]
        public Users User { get; set; }

        [Column("product_id")]
        public Products Product { get; set; }

    }
}