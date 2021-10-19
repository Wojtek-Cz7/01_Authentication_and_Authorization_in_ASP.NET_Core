using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConfArch.Web.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        // konstruktor
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {

        }


        // ten override pozwala na dodanie nowych Claimów do Usera (identity)
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);        // base to są standard identity claims !! 

            // tu dodajemy nowe claimy
            identity.AddClaim(new Claim("CareerStarted", user.CareerStarted.ToShortDateString()));
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }


    }
}
