using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Application.Products.PostProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.PostProduct;
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
    [ProducesResponseType(typeof(PaginatedList<GetAllProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetAllProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetAllProductCommand>(request);

        var response = await _mediator.Send(command, cancellationToken);

        var data = _mapper.Map<List<GetAllProductResponse>>(response.Data);

        var result = new PaginatedList<GetAllProductResponse>(data, response.TotalCount, command.PageNumber, command.PageSize);

        return OkPaginated(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<PostProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] PostProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new PostProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<PostProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<PostProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<PostProductResponse>(response)
        });
    }
}