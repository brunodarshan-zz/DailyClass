using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.UserAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Controllers
{   
    [Route("[controller]")]
    public class UsersController : ApplicationController
    {   
        private UsersRepository _rep;
        
        public UsersController([FromServices] DataContext dbContext) {
            _rep = new UsersRepository(dbContext);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Index(){
            return await _rep.All();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> Show(int id){
            var user = await _rep.Get(id);
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
                await _rep.Create(model);
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
            if (id != model.id){ return NotFound(); }
            else if (!ModelState.IsValid){ return BadRequest(ModelState); }
            

            try {
                await _rep.Update(model);
                return Ok(model);              
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Falha ao atualizar dados"});
            }
        }
    }
}
