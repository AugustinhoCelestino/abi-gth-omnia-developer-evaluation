using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart
{
    public class GetByIdCartProfile : Profile
    {
        public GetByIdCartProfile()
        {
            CreateMap<GetByIdCartCommand, Cart>();
            CreateMap<Cart, GetByIdCartResult>();
        }
    }
}
