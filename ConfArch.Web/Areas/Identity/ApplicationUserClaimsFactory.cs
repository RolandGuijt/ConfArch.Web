using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ConfArch.Web.Areas.Identity
{
    public class ApplicationUserClaimsFactory: UserClaimsPrincipalFactory<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserClaimsFactory(UserManager<ApplicationUser> userManager, 
            IOptions<IdentityOptions> options): base(userManager, options)
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
