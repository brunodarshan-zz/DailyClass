using System.Threading.Tasks;
using DailyClass.Configs;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DailyClass.Domains.Shareds
{
    public abstract class BaseRepository<IEntity>
    {  
       protected DataContext _context;
       public BaseRepository(DataContext ctx){
           _context = ctx;
       }

    }

    public interface IRepo
    {
        
    }
    
}