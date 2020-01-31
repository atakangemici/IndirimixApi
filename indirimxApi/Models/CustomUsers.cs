using indirimxApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Models
{
    public class CustomUsers : BaseEntity
    {
        public string Username { get; set; }
        public string UserSurName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
     
    }
}