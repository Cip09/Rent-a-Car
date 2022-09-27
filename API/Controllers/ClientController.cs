using DatabaseClass;
using DB.DTO;
using DB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _singInManager;
        private RoleManager<IdentityRole> _identityRole;

        private DatabaseContext db { get; set; }

        public ClientController(UserManager<User> userManager, SignInManager<User> singInManager, RoleManager<IdentityRole> identityRole, DatabaseContext db) {

            this._userManager = userManager;
            this._singInManager = singInManager;
            this._identityRole = identityRole;
            this.db = db;

        }


        [HttpPost("/addClient")]

        //POST : /api/ClientController/addClient
        public async Task<Object> addClientUser([FromBody] ApplicationUserModel model)
        {
            var applicationUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,

            };


            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);

                var verifyRole = await this._identityRole.RoleExistsAsync(DB.Entities.UserRole.User.ToString());
                if (!verifyRole) {
                    await this._identityRole.CreateAsync(new IdentityRole(DB.Entities.UserRole.User.ToString()));

                }

                if (result.Succeeded) {
                    result = await _userManager.AddToRoleAsync(applicationUser, DB.Entities.UserRole.User.ToString());

                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("/DeleteClient/{idUser}")]
        public async Task<Object> deleteClient([FromRoute] string idUser) {
            if (idUser == null) {

                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(idUser);

            using (var transation = db.Database.BeginTransaction()) {

                var resul = await _userManager.RemoveFromRoleAsync(user, UserRole.User.ToString());

                await _userManager.DeleteAsync(user);
                transation.Commit();

            }

            return Ok();
        }

        [HttpPut("/updateClient/{idUser}")]
        public async Task<Object> updateClient([FromBody] ApplicationUserModel model, [FromRoute] string idUser) {

            if (idUser == null) {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(idUser);

            user.Email = model.Email;
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.PasswordHash = model.Password;

            await _userManager.UpdateAsync(user);


            return Ok(user);
        }


        [HttpGet("/getClients")]
        public async Task<Object> getAllClients() {
            try
            {
                return Ok(db.User.ToList());
            }catch(Exception ex)
            {
                return BadRequest($"M:  {ex?.Message}    inn:  {ex?.InnerException?.Message}");
            }
            
        }

        [HttpGet("/getClient/{idUser}")]
        public async Task<Object> get1Client([FromRoute] string idUser) {

            var resul = db.User.FirstOrDefault(x => x.Id == idUser);
             return Ok(resul);

            
        }

    }
}
