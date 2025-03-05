using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory
{
    public class GetAllProducFiltredByCategoryProfile : Profile
    {
        public GetAllProducFiltredByCategoryProfile()
        {
            CreateMap<GetAllProductFiltredByCategoryCommand, Product>();
            CreateMap<Product, GetAllProductFiltredByCategoryResult>();
        }
    }
}
