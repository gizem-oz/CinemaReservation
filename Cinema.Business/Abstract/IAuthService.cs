using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IAuthService
    {
        Task<AppIdentityUser> GetUserByName(string username);
        Task<SignInResult> Login(LoginDto model);
        Task<IdentityResult> Register(RegisterDto model);
        Task<IdentityResult> EmployeeRegister(EmployeeRegisterDto model);
        Task<IdentityResult> AdminRegister(AdminRegisterDto model);
        Task<IdentityResult> AddRoleToUser(AppIdentityUser user, string roleName);
        Task<AppIdentityUser> GetUser(string model);
        Task<string> GetRole(string mail);
        Task Logout();
    }
}
