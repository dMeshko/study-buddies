using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using StudyBuddies.Data.Repository.Users;

namespace StudyBuddies.IdentityServer.Factories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var user = _userRepository.Get(x => x.Username == context.UserName);
            if (user != null)
                context.AuthenticateResult = new AuthenticateResult(user.Id.ToString(), user.Username);

            return Task.FromResult(0);
        }

        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userRepository.Get(x => x.Name == context.Subject.Identity.Name);
            var roles = user.Roles;

            var claims = roles.Select(role => new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, role.Name));
            context.IssuedClaims = claims;

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}