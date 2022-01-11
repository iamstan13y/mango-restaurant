using IdentityModel;
using Mango.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Identity.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Client)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new()
            {
                UserName = "iamstan13y@gmail.com",
                Email = "iamstan13y@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0771027274",
                FirstName = "Keith",
                LastName = "Stanley"
            };

            _userManager.CreateAsync(adminUser, "Qwerty123!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Admin),
            }).Result;

            ApplicationUser clientUser = new ApplicationUser()
            {
                UserName = "thecustomer@gmail.com",
                Email = "thecustomer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0771027274",
                FirstName = "The",
                LastName = "Customer"
            };

            _userManager.CreateAsync(clientUser, "Qwerty123!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(clientUser, SD.Client).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(clientUser, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{clientUser.FirstName} {clientUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, clientUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, clientUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Client),
            }).Result;
        }
    }
}