using System.Reflection;
using AutoMapper;

namespace StudyBuddies.Service.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));
        }
    }
}