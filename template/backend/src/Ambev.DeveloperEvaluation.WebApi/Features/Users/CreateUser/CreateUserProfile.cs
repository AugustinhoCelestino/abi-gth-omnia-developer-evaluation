using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>()
            .ForMember(user => user.Firstname, userRequest => userRequest.MapFrom(ur => ur.Name.FirstName))
            .ForMember(user => user.Lastname, userRequest => userRequest.MapFrom(ur => ur.Name.LastName))
            .ForMember(user => user.City, userRequest => userRequest.MapFrom(ur => ur.Address.City))
            .ForMember(user => user.Street, userRequest => userRequest.MapFrom(ur => ur.Address.Street))
            .ForMember(user => user.Number, userRequest => userRequest.MapFrom(ur => ur.Address.Number))
            .ForMember(user => user.Zipcode, userRequest => userRequest.MapFrom(ur => ur.Address.Zipcode))
            .ForMember(user => user.Lat, userRequest => userRequest.MapFrom(ur => ur.Address.Geolocation.Lat))
            .ForMember(user => user.Long, userRequest => userRequest.MapFrom(ur => ur.Address.Geolocation.Long))
            ;

        CreateMap<CreateUserResult, CreateUserResponse>()
            .ForMember(response => response.Name, result => result.MapFrom(r =>
                new UserNameViewModel
                {
                    FirstName = r.Firstname,
                    LastName = r.Lastname
                }))
            .ForMember(response => response.Address, result => result.MapFrom(r =>
                new AddressViewModel
                {
                    City = r.City,
                    Street = r.Street,
                    Number = r.Number,
                    Zipcode = r.Zipcode,
                    Geolocation = new Geolocation
                    {
                        Lat = r.Lat,
                        Long = r.Long
                    } 
                }))
            ;
    }
}
