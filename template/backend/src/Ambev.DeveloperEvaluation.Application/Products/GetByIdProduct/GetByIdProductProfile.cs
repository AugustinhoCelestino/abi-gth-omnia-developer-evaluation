using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct
{
    public class GetByIdProductProfile : Profile
    {
        public GetByIdProductProfile()
        {
            CreateMap<GetByIdProductCommand, Product>();
            CreateMap<Product, GetByIdProductResult>();
        }
    }
}
