using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;
public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResult>();
    }
}
