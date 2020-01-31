using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace indirimxApi.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {

            return Redirect("~/index.html");
        }
    }
}
