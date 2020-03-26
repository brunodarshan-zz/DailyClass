using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.UserAggregate;
using DailyClass.Configs;

namespace DailyClass.Controllers
{   
    [Route("[controller]")]
    public class UsersController : ApplicationController
    {   

        private DbSet<User> _users;
        public UsersController([FromServices] DataContext dbContext) {
            _users = dbContext.Users;
        }


        [HttpGet]
        [Route("")]
        public string Index(){
            return "GET /users";
        }

        [HttpGet]
        [Route("{id:int}")]
        public string Show(int id){
            return "GET /users/"+id.ToString();
        }

        [HttpPost]
        [Route("")]
        public string Create(){
            return "POST /users";
        }

        [HttpPut]
        [Route("{id:int}")]
        public string Update(int id, [FromBody] User model){
            return "PUT /users";
        }

        [HttpDelete]
        [Route("{id:int}")]
        public string Delete(int id){
            return "DELETE /users";
        }
    }
}
