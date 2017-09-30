using System.Reflection;
using AutoMapper;

namespace StudyBuddies.Application.Configuration
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));
        }
    }
}
