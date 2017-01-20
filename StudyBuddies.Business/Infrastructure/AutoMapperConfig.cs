using System.Reflection;
using AutoMapper;

namespace StudyBuddies.Business.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));
        }
    }
}