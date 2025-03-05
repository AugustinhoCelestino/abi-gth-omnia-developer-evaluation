using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Application.Users.GetAllUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ViewModels;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;

public class GetAllProductProfile : Profile
{
    public GetAllProductProfile()
    {
        CreateMap<GetAllProductRequest, GetAllProductCommand>();
        CreateMap<GetAllProductResult, GetAllProductResponse>();
        CreateMap<RatingViewModel, Rating>();
    }
}
