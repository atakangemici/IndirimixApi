using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Products : BaseEntity
    {

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("store")]
        public string Store { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("user_id"), ForeignKey("Users")]
        public int UserId { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }

    }
}