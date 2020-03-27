using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.CourseAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Controllers
{   
    [Route("[controller]")]
    public class CoursesController : ApplicationController
    {   
        private CoursesRepository _rep;
        
        public CoursesController([FromServices] DataContext dbContext) {
            _rep = new CoursesRepository(dbContext);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Course>>> Index(){
            return await _rep.All();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Course>> Show(int id){
            var Course = await _rep.Get(id);
            if (Course!=null)
                return Ok(Course);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Course>> Create(
            [FromBody] Course model, 
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
        public async Task<ActionResult<Course>> Update(
            int id,
            [FromBody] Course model,
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
