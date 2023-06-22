using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public interface IAccountRepository
    {

        public Task<IdentityResult> SignUp(SignUpModel signUpModel);
        public Task<string> Login(SignInModel signInModel);
        public Task SignOut();
    }
}
