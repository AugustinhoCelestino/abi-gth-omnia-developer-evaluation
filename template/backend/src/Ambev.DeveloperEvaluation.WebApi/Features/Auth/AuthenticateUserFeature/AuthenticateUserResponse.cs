using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;

public sealed class AuthenticateUserResponse
{
    public string Token { get; set; } = string.Empty;
}
