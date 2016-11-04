using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyBuddies.Domain.Models;
using StudyBuddies.Web.ViewModels;

namespace StudyBuddies.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterUserViewModel, User>();
        }
    }
}