using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory;
using Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProductFiltredByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByIdProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
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
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        var mappedData = _mapper.Map<CreateProductResponse>(response);

        var apirepsonse = new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = mappedData
        };

        return Created(string.Empty, apirepsonse);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetByIdProductRequest { Id = id };
        var validator = new GetByIdProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetByIdProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetByIdProductResponse>
        {
            Success = true,
            Message = "Product found successfully",
            Data = _mapper.Map<GetByIdProductResponse>(response)
        });
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { Id = id };

        var validator = new DeleteProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductCommand>(request);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductViewModel request, [FromRoute] int id, CancellationToken cancellationToken)
    {
        var productToUpdate = _mapper.Map<UpdateProductRequest>(request);
        productToUpdate.Id = id;

        var validator = new UpdateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(productToUpdate, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateProductCommand>(productToUpdate);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateProductResponse>
        {
            Success = true,
            Message = "Product updated successfully",
            Data = _mapper.Map<UpdateProductResponse>(response)
        });
    }

    [HttpGet("categories")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
    {
        var command = new GetAllCategoriesCommand();

        var response = await _mediator.Send(command, cancellationToken);

        var data = response.Category;

        return Ok(data);
    }

    [HttpGet("categories/{category}")]
    [ProducesResponseType(typeof(PaginatedList<GetAllProductFiltredByCategoryResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProductFiltredByCategory([FromQuery] ProductFiltredByCategoryViewModel request, [FromRoute] string category, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<GetAllProductFiltredByCategoryRequest>(request);
        filter.Category = category;

        var validator = new GetAllProductFiltredByCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(filter, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetAllProductFiltredByCategoryCommand>(filter);

        var response = await _mediator.Send(command, cancellationToken);

        var data = _mapper.Map<List<GetAllProductFiltredByCategoryResponse>>(response.Data);

        var result = new PaginatedList<GetAllProductFiltredByCategoryResponse>(data, response.TotalCount, command.PageNumber, command.PageSize);

        return OkPaginated(result);
    }
}