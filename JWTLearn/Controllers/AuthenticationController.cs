using JWTLearn.Models;
using JWTLearn.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTLearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User Model)
        {
            var user = _authenticateService.Authenticate(Model.UserName, Model.Password);

            if (user == null)
            {
                return BadRequest(new { Message = "UserName / Password is incorrect" });
            }

            return Ok(user);
        }


    }
}
