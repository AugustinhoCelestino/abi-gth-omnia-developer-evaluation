using Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;
using Ambev.DeveloperEvaluation.Application.PagnatedResult;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, PagnatedResult<List<GetAllProductResult>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<PagnatedResult<List<GetAllProductResult>>> Handle(GetAllProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var ProductsList =
                await _repository.GetAllPaginatedAsync(
                    command.PageNumber,
                    command.PageSize,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllProductResult>>(ProductsList);

            PagnatedResult<List<GetAllProductResult>> resultList = new();

            resultList.Data = result;

            resultList.TotalCount = await _repository.GetTotalCount();

            return resultList;
        }
    }
}
