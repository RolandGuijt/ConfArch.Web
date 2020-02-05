using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ConfArch.Web.Areas.Identity
{
    public class ApplicationUserClaimsFactory: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserClaimsFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> options): base(userManager, roleManager, options)
        {
            this.userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("CareerStarted", user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }
    }
}
