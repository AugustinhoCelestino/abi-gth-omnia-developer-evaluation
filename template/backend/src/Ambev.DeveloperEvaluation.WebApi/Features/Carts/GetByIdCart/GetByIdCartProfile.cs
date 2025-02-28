using Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetByIdCart;

public class GetByIdCartProfile : Profile
{
    public GetByIdCartProfile()
    {
        CreateMap<GetByIdCartRequest, GetByIdCartCommand>();
        CreateMap<GetByIdCartResult, GetByIdCartResponse>();
    }

}
