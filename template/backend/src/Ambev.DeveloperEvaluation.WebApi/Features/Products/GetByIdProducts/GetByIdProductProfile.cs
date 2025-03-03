using Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByIdProducts;

public class GetByIdProductProfile : Profile
{
    public GetByIdProductProfile()
    {
        CreateMap<GetByIdProductRequest, GetByIdProductCommand>();
        CreateMap<GetByIdProductResult, GetByIdProductResponse>();
    }
}
