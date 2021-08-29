using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Attributes;
using prjShoeStore.Common;
using prjShoeStore.DTO;
using prjShoeStore.Options;

namespace prjShoeStore.Controllers
{
    [AuthorizeJWT]
    public class TokenController : ApiBaseController
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly JwtSetting _JwtSetting;
        public TokenController(
            UserManager<ApplicationUser> userManager,
            JwtSetting jwtSetting,
            SignInManager<ApplicationUser> signInManager)
        {
            _UserManager = userManager;
            _JwtSetting = jwtSetting;
            _SignInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var user = await _UserManager.GetUserAsync(HttpContext.User);
            if (user == null) return NotFound();
            var resut = await _UserManager.RemoveAuthenticationTokenAsync(user, Helper.LoginProvider, Helper.Purpose);
            return Ok(resut.Succeeded);
        }
        private async Task<ApplicationUser> CheckLogin(UserDTO userDTO)
        {
            var user = await _UserManager.FindByEmailAsync(userDTO.UserName);
            if (user == null) return null;
            var result = await _UserManager.CheckPasswordAsync(user, userDTO.PassWord);
            return user;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileAsync()
        {
            var user = await _UserManager.GetUserAsync(HttpContext.User);

            return Ok(new UserDTO
            {
                Address = user.Address,
                Birthday = user.Birthday,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                UserName = user.UserName
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfileAsync([FromForm] UserDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _UserManager.GetUserAsync(HttpContext.User);

            user.Address = userDTO.Address;
            user.Birthday = userDTO.Birthday;
            user.FirstName = userDTO.FirstName;
            user.Gender = userDTO.Gender;
            user.LastName = userDTO.LastName;
            user.UserName = userDTO.UserName;

            await _UserManager.UpdateAsync(user);

            return Ok(new UserDTO
            {
                Address = user.Address,
                Birthday = user.Birthday,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                UserName = user.UserName
            });
        }
        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JwtSetting.SecretKey);
            var claims = new List<Claim>();
            var listRoles = await _UserManager.GetRolesAsync(user);
            if (listRoles != null)
                foreach (var item in listRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(_JwtSetting.TokenExpireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            await _UserManager.SetAuthenticationTokenAsync(user, Helper.LoginProvider, Helper.Purpose, tokenString);
            return tokenString;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {
            var result = await _SignInManager.PasswordSignInAsync(userDTO.UserName, userDTO.PassWord, false, true);
            if (result.Succeeded)
            {
                return Ok(await GenerateToken(await _UserManager.FindByNameAsync(userDTO.UserName)));
            }
            else
            {
                return BadRequest("Login information  is incorrect!");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser
            {
                UserName = userDTO.UserName,
                Email = userDTO.UserName,
                Gender = userDTO.Gender,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Birthday = userDTO.Birthday,
                Address = userDTO.Address
            };
            var result = await _UserManager.CreateAsync(user, userDTO.PassWord);
            if (result.Succeeded)
            {
                return Ok(await GenerateToken(user));
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
