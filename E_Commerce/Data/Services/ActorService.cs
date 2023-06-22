using E_Commerce.Data.Base;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace E_Commerce.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context) 
        {
        
        }

    }
}








//public async Task Add(Actor actor)
//{
//    await _context.Actors.AddAsync(actor);
//    await _context.SaveChangesAsync();
//}

//public async Task Delete(int id)
//{
//    var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

//    _context.Actors.Remove(result);
//    await _context.SaveChangesAsync();

//    //await _context.Actors.RemoveAsync(id);
//}

//    public async Task<IEnumerable<Actor>> GetAll()
//    {
//        var result = await _context.Actors.ToListAsync();
//        return result;
//    }

//    public async Task<Actor> GetById(int id)
//    {
//        var data = await _context.Actors.FindAsync(id);
//        var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

//        return data;
//    }

//    public async Task<Actor> Update(int id, Actor newactor)
//    {
//        _context.Update(newactor);
//        await _context.SaveChangesAsync();
//        return newactor;
//    }