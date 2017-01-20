using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Business.ViewModels.Users
{
    [Validator(typeof(MessageViewModelValidator))]
    public class MessageViewModel
    {
        public Guid UserFromId { get; set; }
        public Guid UserToId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }

    public class MessageViewModelValidator : AbstractValidator<MessageViewModel>
    {
        public MessageViewModelValidator()
        {
            RuleFor(x => x.UserFromId)
                .NotEmpty();

            RuleFor(x => x.UserToId)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }

    public class MessageViewModelMappingProfile : Profile
    {
        public MessageViewModelMappingProfile()
        {
            CreateMap<Message, MessageViewModel>()
                .ForMember(x => x.UserFromId, opt => opt.MapFrom(y => y.UserFrom.Id))
                .ForMember(x => x.UserToId, opt => opt.MapFrom(y => y.UserTo.Id));
        }
    }
}
