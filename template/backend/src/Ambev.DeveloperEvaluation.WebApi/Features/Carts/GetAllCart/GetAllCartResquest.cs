using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart;

public class GetAllCartRequest
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public bool OrderByDesc { get; set; } = false;

    public List<string>? OrderBy { get; set; } = new List<string>{"Id","UserId"};
}
