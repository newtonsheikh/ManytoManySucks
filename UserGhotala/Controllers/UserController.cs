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
using Microsoft.EntityFrameworkCore.Proxies;

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

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            return Ok(users);
        }

        [Route("api/User")]
        [HttpGet("api/User/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(null);
        }



    }
}