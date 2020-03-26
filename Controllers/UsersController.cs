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
        public async Task<ActionResult<List<User>>> Index(){
            return await _users.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> Show(int id){
            var user = await GetUserById(id);
            if (user!=null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Create(
            [FromBody] User model, 
            [FromServices] DataContext dbContext )
            {
            if(ModelState.IsValid) {
                _users.Add(model);
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> Update(
            int id,
            [FromBody] User model,
            [FromServices] DataContext dbContext)
        {
            if (id != model.ID){ return NotFound(); }
            else if (!ModelState.IsValid){ return BadRequest(ModelState); }
            else if(await GetUserById(id) != null){
                dbContext.Entry<User>(model).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }
            else { return NotFound(); }
        }

         private async Task<User> GetUserById(int id){
            return await _users.FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
