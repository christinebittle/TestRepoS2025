using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1N0000000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1Controller : ControllerBase
    {

        /// <summary>
        /// This method receives a get request and produces a string response
        /// </summary>
        /// <returns>A test string</returns>
        /// <example>
        /// GET : localhost:xx/api/Q1 -> "This is a test"
        /// </example>
        [HttpGet]
        public string Get()
        {
            return "This is a test";
        }

        /// <summary>
        /// This method receives a POST request and provides a test response
        /// </summary>
        /// <returns>A string response</returns>
        /// <example>
        /// POST : localhost:xx/api/Q1 -> 3
        /// </example>
        [HttpPost]
        public int Post()
        {
            return 3;
        }
    }
}
