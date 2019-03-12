using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TMSApi.Controllers
{
    /// <summary>
    /// Account controller used for account management
    /// like registration or authentication(login)
    /// </summary>
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User credentials)
        {
            var user = new User { UserName = credentials.UserName, Email = credentials.UserName };

            var result = await userManager.CreateAsync(user, credentials.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await signInManager.SignInAsync(user, isPersistent: false);

            return Ok(CreateToken(user));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User credentials)
        {
            var result = await signInManager.PasswordSignInAsync(credentials.UserName, credentials.Password, false, false);

            if (!result.Succeeded)
                return BadRequest();

            var user = await userManager.FindByEmailAsync(credentials.UserName);

            return Ok(CreateToken(user));
        }

        string CreateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret phrase"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
