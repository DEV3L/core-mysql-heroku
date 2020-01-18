using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace core_mysql_heroku.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// This is a simple Get Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() =>
            {
                return Ok("OK!");
            });
        }
    }
}
