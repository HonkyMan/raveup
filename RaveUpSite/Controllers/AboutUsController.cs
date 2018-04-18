using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RaveUpSite.Controllers
{
    public class AboutUsController : Controller
    {
        public AboutUsController() { }

        public ViewResult About() => View();
    }
}
