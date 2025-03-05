using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdUser
{
    public class GetByIdUserProfile : Profile
    {
        public GetByIdUserProfile()
        {
            CreateMap<GetByIdUserCommand, User>();
            CreateMap<User, GetByIdUserResult>();
        }
    }
}
