using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatabaseClass;
using DB.DTO;
using DB.Entities;
using DB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace API.Controllers
{
    [Route("[controller]")]
    public class ApplicationUserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _singInManager;
        private readonly ApplicationSettings _appSettings;
        private DatabaseContext db { get; set; }
        private RoleManager<IdentityRole> _identityRole;
        private IRentScheduling _rentScheduling;

        public ApplicationUserController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettings> appSettings, DatabaseContext db, RoleManager<IdentityRole> _identityRole, IRentScheduling rentScheduling)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            this.db = db;
            this._identityRole = _identityRole;
            this._rentScheduling = rentScheduling;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser([FromBody] ApplicationUserModel model)
        {
            var applicationUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await this._identityRole.CreateAsync(new IdentityRole(DB.Entities.UserRole.User.ToString()));

                result = await _userManager.AddToRoleAsync(applicationUser, DB.Entities.UserRole.User.ToString());
                return Ok(result);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {


                if (!db.User.Any())
                {
                    var adminUser = new User()
                    {
                        UserName = "admin",

                        FullName = "admin"

                    };

                    var result = await _userManager.CreateAsync(adminUser, model.Password);

                    await this._identityRole.CreateAsync(new IdentityRole(DB.Entities.UserRole.Admin.ToString()));

                    result = await _userManager.AddToRoleAsync(adminUser, DB.Entities.UserRole.Admin.ToString());

                }

                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var role = await _userManager.GetRolesAsync(user);
                    var result = role.FirstOrDefault();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim("RoleName",result),
                        new Claim(ClaimTypes.Actor, user.Id),
                        new Claim(ClaimTypes.Role, result)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    return BadRequest(new { message = "Username or password is incorrect." });

            }
            catch (Exception e)
            {
                return BadRequest(e?.Message?.ToString() + " " + e?.InnerException.Message?.ToString());
            }
        }
        [HttpGet("Alert")]
        public IActionResult getAler()
        {
            try
            {
                var userRole = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Role)?.Value;
                var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                var result = this._rentScheduling.getAlert(userRole, userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e?.Message);
            }
        }
        [HttpGet("AllAlert")]
        public IActionResult getAllAlert()
        {
            try
            {
                var userRole = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Role)?.Value;
                var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                var result = this._rentScheduling.getAllAlert(userRole, userId);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e?.Message);
            }


        }
    }
}