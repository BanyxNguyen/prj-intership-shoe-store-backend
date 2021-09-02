using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.AuthorizeHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Controllers
{
    public class BuildAppController : ApiBaseController
    {
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        public BuildAppController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _RoleManager = roleManager;
            _UserManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GenerateRoleAsync()
        {
            if (!await _RoleManager.RoleExistsAsync(AuthorizeManage.RoleAdmin))
            {
                await _RoleManager.CreateAsync(new IdentityRole
                {
                    Name = AuthorizeManage.RoleAdmin
                });
            }
            if (!await _RoleManager.RoleExistsAsync(AuthorizeManage.RoleUser))
            {
                await _RoleManager.CreateAsync(new IdentityRole
                {
                    Name = AuthorizeManage.RoleUser
                });
            }
            return Ok(true);
        }
        public class UserAdmin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAdmin([FromBody] UserAdmin userAdmin)
        {
            var user = new ApplicationUser
            {
                Email = userAdmin.Email,
                UserName = userAdmin.Email
            };
            var usertmp = await _UserManager.FindByEmailAsync(user.Email);
            if (usertmp == null)
            {
                var result = await _UserManager.CreateAsync(user, userAdmin.Password);
                if (result.Succeeded)
                {
                    usertmp = await _UserManager.FindByEmailAsync(userAdmin.Email);
                    result = await _UserManager.AddToRoleAsync(usertmp, AuthorizeManage.RoleAdmin);
                    if (!result.Succeeded)
                    {
                        await _UserManager.DeleteAsync(user); 
                        return BadRequest(result.Errors);
                    }

                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return Ok(true);

        }
    }
}
