﻿using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Models;
using PrimeiraAPI.Services;

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
                var token = TokenService.GenerateToken(new Models.Employee(username, newPassword, null));
                return Ok(token);
            }

            return BadRequest("Username or password invalid!");
        }
    }
}
