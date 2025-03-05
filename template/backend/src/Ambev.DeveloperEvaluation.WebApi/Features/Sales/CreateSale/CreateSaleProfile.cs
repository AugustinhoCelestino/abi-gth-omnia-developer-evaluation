using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ViewModel;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>()
            .ForMember(response => response.SaleNumber, result => result.MapFrom(r => r.Id))
            .ForMember(response => response.Products, result => result.MapFrom(r => r.ProductsSold))
            ;
        CreateMap<ProductsSoldViewModel, ProductsSold>().ReverseMap();
    }
}