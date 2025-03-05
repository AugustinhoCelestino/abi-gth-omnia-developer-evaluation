using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    public class GetAllCartProfile : Profile
    {
        public GetAllCartProfile()
        {
            CreateMap<GetAllCartCommand, Cart>();
            CreateMap<Cart, GetAllCartResult>();
        }
    }
}
