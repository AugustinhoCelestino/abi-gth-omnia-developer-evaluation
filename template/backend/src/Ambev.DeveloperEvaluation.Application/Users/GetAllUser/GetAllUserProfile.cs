using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser
{
    public class GetAllUserProfile : Profile
    {
        public GetAllUserProfile()
        {
            CreateMap<GetAllUserCommand, User>();
            CreateMap<User, GetAllUserResult>();
        }
    }
}
