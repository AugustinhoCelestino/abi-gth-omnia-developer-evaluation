using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartRequest, UpdateCartCommand>();
        CreateMap<UpdateCartResult, UpdateCartResponse>()
            .ForMember(
            CartResult => CartResult.Products,
            CartResponse => CartResponse.MapFrom(r => r.CartItems));

        CreateMap<UpdateCartViewModel, UpdateCartRequest>();
        CreateMap<CartItemViewModel, CartItem>()
            .ReverseMap();

    }
}