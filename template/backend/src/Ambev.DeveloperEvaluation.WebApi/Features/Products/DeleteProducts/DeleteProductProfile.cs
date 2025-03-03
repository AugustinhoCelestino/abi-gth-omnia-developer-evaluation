using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<DeleteProductRequest, DeleteProductCommand>();
    }
}
