using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.CourseAggregate;
using DailyClass.Domains.ModuleAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Controllers
{  
    [Route("[controller]")]
    public class ModulesController : ApplicationController
    {   
        private ModulesRepository _rep;
        
        public ModulesController([FromServices] DataContext dbContext) {
            _rep = new ModulesRepository(dbContext);
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Module>>> Index(){
            return await _rep.All();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Module>> Show(int id){
            var course = await _rep.Get(id);
            if (course!=null)
                return Ok(course);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Module>> Create(
            [FromBody] Module model, 
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
        public async Task<ActionResult<Module>> Update(
            int id,
            [FromBody] Module model,
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
