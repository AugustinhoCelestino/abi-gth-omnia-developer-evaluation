using Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ViewModels;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;

public class GetAllProductFiltredByCategoryProfile : Profile
{
    public GetAllProductFiltredByCategoryProfile()
    {
        CreateMap<GetAllProductFiltredByCategoryRequest, GetAllProductFiltredByCategoryCommand>();
        CreateMap<GetAllProductFiltredByCategoryResult, GetAllProductFiltredByCategoryResponse>();
        CreateMap<RatingViewModel, Rating>();
        CreateMap<ProductFiltredByCategoryViewModel, GetAllProductFiltredByCategoryRequest>();
    }
}
