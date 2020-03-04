using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class Users : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("sure_name")]
        public string SureName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("role")]
        public string Role { get; set; }

    }
}