using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Cart>()
            .ForMember(
            Cart => Cart.CartItems,
            CartCommand => CartCommand.MapFrom(r => r.Products)); 

        CreateMap<Cart, CreateCartResult>();
    }
}
