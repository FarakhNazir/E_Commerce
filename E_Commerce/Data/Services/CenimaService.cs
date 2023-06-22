using E_Commerce.Data.Base;
using E_Commerce.Models;
using System.Security.Policy;

namespace E_Commerce.Data.Services
{
    public class CenimaService : EntityBaseRepository<Cenima>, ICenimaService
    {
        public CenimaService(AppDbContext appDbContext) : base(appDbContext) 
        {

        }
    }
}
