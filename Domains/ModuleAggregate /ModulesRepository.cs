using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DailyClass.Domains.ModuleAggregate;
using DailyClass.Domains.CourseAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Domains.ModuleAggregate
{
    public class ModulesRepository : BaseRepository<Module>
    {

        public ModulesRepository(DataContext opt) : base(opt){}

        public async Task<List<Module>> All(){
            return await _context.Modules
                                 .Include(module => module.Course)
                                 .ToListAsync();
        }

        public async Task<List<Module>> ListByCourse(Course course) {
            return await _context.Modules
                                 .Include(module => module.Course)
                                 .Where(module => module.Course == course)
                                 .ToListAsync();
        }


        public async Task<Module> Get(int value) {
           return await _context.Modules
                                .Include(module => module.Course)
                                .FirstOrDefaultAsync(x => x.id == value); 
        }
        
        public async Task<Module> Create(Module model){
            _context.Modules.Add(model);
            await _context.SaveChangesAsync();
            return await Get(model.id);
        }

        public async Task<Module> Update(Module model){
            _context.Entry<Module>(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await Get(model.id);
        }

    }
}