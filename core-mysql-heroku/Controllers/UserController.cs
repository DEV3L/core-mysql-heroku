using System;
using System.Threading.Tasks;
using core_mysql_heroku.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace core_mysql_heroku.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ConnectionStrings connectionStrings;
        public UserController(ConnectionStrings ConnectionStrings)
            => connectionStrings = ConnectionStrings;

        /// <summary>
        /// List users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] User user)
        {
            return await Task.Run(() =>
            {
                using var connection = new MySqlConnection(connectionStrings.MySQL);
                var sql = @"SELECT * FROM user 
                                WHERE (@id = 0 OR id = @id) 
                                AND (@name IS NULL OR UPPER(name) = UPPER(@name))";
                var query = connection.Query<User>(sql, user, commandTimeout: 30);
                return Ok(query);
            });
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            return await Task.Run(() =>
            {
                using var connection = new MySqlConnection(connectionStrings.MySQL);
                var sql = @"INSERT INTO user (name) VALUES (@name)";
                connection.Execute(sql, user, commandTimeout: 30);
                return Ok();
            });
        }
    }
}
