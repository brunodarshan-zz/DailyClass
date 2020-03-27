using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DailyClass.Domains.CourseAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Domains.CourseAggregate
{
    public class CoursesRepository : BaseRepository<Course>
    {

        public CoursesRepository(DataContext opt) : base(opt){}

        public async Task<List<Course>> All(){
            return await _context.Courses.ToListAsync();
        }
        
        public async Task<Course> Create(Course model){
            _context.Courses.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Course> Get(int value) {
           return await _context.Courses.FirstOrDefaultAsync(x => x.id == value); 
        }

        public async Task<Course> Update(Course model){
            _context.Entry<Course>(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

    }
}