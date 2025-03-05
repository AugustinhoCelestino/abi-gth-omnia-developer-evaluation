using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetByIdCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/[controller]")]
public class CartController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CartController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<GetAllCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCart([FromQuery] GetAllCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetAllCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetAllCartCommand>(request);

        var response = await _mediator.Send(command, cancellationToken);

        var data = _mapper.Map<List<GetAllCartResponse>>(response.Data);

        var result = new PaginatedList<GetAllCartResponse>(data, response.TotalCount, command.PageNumber, command.PageSize);

        return OkPaginated(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = _mapper.Map<CreateCartResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdCartResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdCart([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetByIdCartRequest { Id = id };
        var validator = new GetByIdCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetByIdCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetByIdCartResponse>
        {
            Success = true,
            Message = "Cart found successfully",
            Data = _mapper.Map<GetByIdCartResponse>(response)
        });
    }
}