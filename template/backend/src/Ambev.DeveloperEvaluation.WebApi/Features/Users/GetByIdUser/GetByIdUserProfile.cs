using Ambev.DeveloperEvaluation.Application.Users.GetByIdUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.ViewModel;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdUser;

public class GetByIdUserProfile : Profile
{
    public GetByIdUserProfile()
    {
        CreateMap<GetByIdUserRequest, GetByIdUserCommand>();

        CreateMap<GetByIdUserResult, GetByIdUserResponse>()
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
