using Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart;

public class GetAllCartProfile : Profile
{
    public GetAllCartProfile()
    {
        CreateMap<GetAllCartRequest, GetAllCartCommand>();
        CreateMap<GetAllCartResult, GetAllCartResponse>()
            .ForMember(
            CartResult => CartResult.Products,
            CartResponse => CartResponse.MapFrom(r => r.CartItems)); 
    }
}