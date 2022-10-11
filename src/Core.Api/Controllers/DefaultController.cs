using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
        public string Index() => "Running...";
    }
}
