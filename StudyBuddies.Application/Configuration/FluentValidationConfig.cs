using System.Web.Http;
using FluentValidation.WebApi;

namespace StudyBuddies.Application.Configuration
{
    public class FluentValidationConfig
    {
        public static void Configure(HttpConfiguration globalConfiguration)
        {
            FluentValidationModelValidatorProvider.Configure(globalConfiguration);
        }
    }
}
