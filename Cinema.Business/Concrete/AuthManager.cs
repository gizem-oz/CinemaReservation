using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<AppIdentityRole> _roleManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public AuthManager(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddRoleToUser(AppIdentityUser user, string roleName)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=>x.Name == roleName);
            if (role ==null)
            {
                await _roleManager.CreateAsync(new AppIdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() });
            }
            
            return await _userManager.AddToRoleAsync(user, roleName);
            
        }

        public async Task<SignInResult> Login(LoginDto model)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == model.Email);

            if (user is null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,false);

            return result;
        }
        //public async Task<AppIdentityUser> GetUser(string email)
        public async Task<AppIdentityUser> GetUser(string email)
        {
            var user = _userManager.Users.FirstOrDefault(x=>x.Email == email);
            return user;
        }
        public async Task< AppIdentityUser> GetUserByName(string username)
        {
            
            var user =_userManager.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                
            }
            return user;
        }

        public async Task<string> GetRole(string mail)
        {
            
            AppIdentityUser user = await GetUser(mail);
            if (user is not null)
            {
                var roleList = await _userManager.GetRolesAsync(user);
                if (roleList.Count > 0)
                {
                    return roleList[0];
                }
            }
            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = new AppIdentityUser{UserName = model.UserName,Email = model.Email};
            var customer = new Customer { FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, Status = false };
            user.Customer = customer;
            var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await AddRoleToUser(user, "User");
                }
                return result;
        }
        public async Task<IdentityResult> EmployeeRegister(EmployeeRegisterDto model)
        {
            var user = new AppIdentityUser { UserName = model.UserName, Email = model.Email };
            var employee = new Employee { FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, Status = false, Adress=model.Adress, DepartmentId=model.DepartmentId};
            user.Employee = employee;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Employee");
            }
            return result;
        }
        public async Task<IdentityResult> AdminRegister(AdminRegisterDto model)
        {
            var user = new AppIdentityUser { Email = model.Email, UserName=model.UserName, PhoneNumber = model.PhoneNumber };
            
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Admin");
            }
            return result;
        }
    }
}
