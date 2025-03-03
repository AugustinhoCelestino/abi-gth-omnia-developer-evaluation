using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory
{
    public class GetAllProducFiltredByCategorytProfile : Profile
    {
        public GetAllProducFiltredByCategorytProfile()
        {
            CreateMap<GetAllProductFiltredByCategoryCommand, Product>();
            CreateMap<Product, GetAllProductFiltredByCategoryResult>();
        }
    }
}
