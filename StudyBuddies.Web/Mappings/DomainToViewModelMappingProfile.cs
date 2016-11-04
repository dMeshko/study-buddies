using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using StudyBuddies.Domain.Models;
using StudyBuddies.Web.ViewModels;

namespace StudyBuddies.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Message, SentMessageViewModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(y => y.UserTo))
                .MaxDepth(1);

            CreateMap<Message, ReceivedMessageViewModel>()
                .ForMember(x => x.User, opt => opt.MapFrom(y => y.UserFrom))
                .MaxDepth(1);

            CreateMap<User, UserViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Name} {y.Surname}"))
                .ForMember(x => x.Image, opt => opt.MapFrom(y => Convert.ToBase64String(y.Image)))
                .ForMember(x => x.Rating, opt => opt.MapFrom(
                    y => y.MemberInGroups
                     .Where(z => z.Status && z.Group.ExpireDate.CompareTo(DateTime.Now) >= 0) //gives the participated groups
                     .Select(z => z.Group.Ratings //gets average
                         .Where(w => w.UserTo.Id == y.Id) //gets the grades he has got for the grp
                         .Select(e => e.Grade)
                         .DefaultIfEmpty()
                         .Sum()) //average rating for the grp
                     .DefaultIfEmpty()
                     .Sum() //average rating for all groups
                     )
                );

            /*
              SELECT [gr].UserTo_id, AVG([gr].grade)
              FROM [StudyBuddies].[dbo].[GroupRating] as [gr]
              GROUP BY [gr].UserTo_id
             */

        }
    }
}