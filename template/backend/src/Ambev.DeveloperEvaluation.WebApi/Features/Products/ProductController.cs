using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithPaginatedData<List<GetAllProductResponse>>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCart([FromQuery] GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetAllProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetAllProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        var data = _mapper.Map<List<GetAllProductResponse>>(response);

        return Ok(new ApiResponseWithPaginatedData<List<GetAllProductResponse>>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = data,
            TotalItems = 1,
            CurrentPage = 1,
            TotalPages = 1            
        });
    }
}