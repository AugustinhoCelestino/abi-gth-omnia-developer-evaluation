using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductProfile : Profile
{
    public GetAllProductProfile()
    {
        CreateMap<GetAllProductRequest, GetAllProductCommand>();
        CreateMap<GetAllProductResult, GetAllProductResponse>();
    }
}
