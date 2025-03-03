using Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart;
using Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetByIdCart;

public class GetByIdCartProfile : Profile
{
    public GetByIdCartProfile()
    {
        CreateMap<GetByIdCartRequest, GetByIdCartCommand>();
        CreateMap<GetByIdCartRequest, GetByIdCartCommand>();
        CreateMap<GetByIdCartResult, GetByIdCartResponse>();
    }

}
