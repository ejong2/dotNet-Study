using dotNetStudy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetStudy.Controllers
{
    [ApiController]
    [Route("api/v1/hello")]
    public class HelloWorldController : ControllerBase
    {
        private readonly AriaContext _context;

        public HelloWorldController(AriaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            return "HelloWorld";
        }
    }
}
