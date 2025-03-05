using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;

public sealed class AuthenticateUserProfile : Profile
{
    public AuthenticateUserProfile()
    {
        CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();

        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
    }
}
