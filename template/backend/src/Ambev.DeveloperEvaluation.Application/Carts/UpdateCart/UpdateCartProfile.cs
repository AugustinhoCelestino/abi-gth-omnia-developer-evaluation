using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartCommand, Cart>()
            .ForMember(
            Cart => Cart.CartItems,
            CartCommand => CartCommand.MapFrom(r => r.Products));

        CreateMap<Cart, UpdateCartResult>();
    }
}
