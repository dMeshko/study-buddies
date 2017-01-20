using System.Web.Http;
using FluentValidation.WebApi;

namespace StudyBuddies.Business.Infrastructure
{
    public class FluentValidatoinConfig
    {
        public static void Configure(HttpConfiguration globalConfiguration)
        {
            FluentValidationModelValidatorProvider.Configure(globalConfiguration);
        }
    }
}
