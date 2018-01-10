using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.Default;

namespace StudyBuddies.IdentityServer.Services
{
    public class CustomUserService : UserServiceBase
    {


        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            
        }
    }
}