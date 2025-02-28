using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    public class GetAllProductProfile : Profile
    {
        public GetAllProductProfile()
        {
            CreateMap<GetAllProductCommand, Product>();
            CreateMap<Product, GetAllProductResult>();
        }
    }
}
