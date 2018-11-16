using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCodeSnipper.Controllers
{
    [Route("api/[controller]")]
    public class DefaultController : Controller
    {
        public string Get()
        {
            return "hello world";
        }

        public string About()
        {
            return "About";
        }
    }
}