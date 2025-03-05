using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ViewModel;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>()
            .ForMember(
            CartResult => CartResult.Products, 
            CartResponse => CartResponse.MapFrom(r => r.CartItems));

        CreateMap<CartItemViewModel, CartItem>()
            .ReverseMap();
    }
}