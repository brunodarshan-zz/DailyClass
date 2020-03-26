using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DailyClass.Domains.UserAggregate;
using DailyClass.Domains.Shareds;
using DailyClass.Configs;

namespace DailyClass.Domains.UserAggregate
{
    public class UsersRepository : BaseRepository<User>
    {

        public UsersRepository(DataContext opt) : base(opt){}

        public async Task<List<User>> All(){
            return await _context.Users.ToListAsync();
        }
        
        public async Task<User> Create(User model){
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<User> Get(int value) {
           return await _context.Users.FirstOrDefaultAsync(x => x.ID == value); 
        }

        public async Task<User> Update(User model){
            _context.Entry<User>(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

    }
}