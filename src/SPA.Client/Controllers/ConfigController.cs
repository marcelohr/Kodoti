using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConfigController(IConfiguration configuration) => this._configuration = configuration;

        [HttpGet]
        public ActionResult Index() => Ok(new { 
            ApiUrl = _configuration.GetValue<string>("ApiUrl")
        });
    }
}
