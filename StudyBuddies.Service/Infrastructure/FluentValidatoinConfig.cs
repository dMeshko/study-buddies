using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation.WebApi;
using static FluentValidation.WebApi.FluentValidationModelValidatorProvider;

namespace StudyBuddies.Service.Infrastructure
{
    public class FluentValidatoinConfig
    {
        public static void Configure(HttpConfiguration globalConfiguration)
        {
            FluentValidationModelValidatorProvider.Configure(globalConfiguration);
        }
    }
}
