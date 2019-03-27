using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserGhotala.Data;
using UserGhotala.Data.Models;

namespace UserGhotala.Controllers
{
    public class UserController : ControllerBase
    {
        [Route("api/Users")]
        [HttpGet("api/Users")]
        public async Task<IActionResult> GetUsers() {

            List<User> users = null;
            using (var context = new UserContext()) {
                users = context.Users.Include(ur => ur.UserRoles).ToList();
            }
            return Ok(users);
        }

        [Route("api/User")]
        [HttpGet("api/User/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(null);
        }

        [Route("api/AddUser")]
        [HttpPost("api/AddUser")]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {

            try {
                using (var context = new UserContext()) {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) {

            }
            return Ok("Done!");
        }


    }
}