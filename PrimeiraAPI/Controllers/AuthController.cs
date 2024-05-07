using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Application.Services;
using PrimeiraAPI.Domain.Models;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "andre" && password == "123456")
            {
                var newPassword = int.Parse(password);
                var token = TokenService.GenerateToken(new Domain.Models.EmployeeAggregate.Employee(username, newPassword, null));
                return Ok(token);
            }

            return BadRequest("Username or password invalid!");
        }
    }
}
