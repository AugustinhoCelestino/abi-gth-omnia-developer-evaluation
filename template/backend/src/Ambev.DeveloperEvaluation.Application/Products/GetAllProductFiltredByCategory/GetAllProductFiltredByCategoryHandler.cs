using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProductFiltredByCategory
{
    public class GetAllProductFiltredByCategoryHandler : IRequestHandler<GetAllProductFiltredByCategoryCommand, PagnatedResult<List<GetAllProductFiltredByCategoryResult>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductFiltredByCategoryHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<PagnatedResult<List<GetAllProductFiltredByCategoryResult>>> Handle(GetAllProductFiltredByCategoryCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductFiltredByCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var ProductsList =
                await _repository.GetAllPaginatedFiltredByCategoryAsync(
                    command.PageNumber,
                    command.PageSize,
                    command.Category,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllProductFiltredByCategoryResult>>(ProductsList);

            PagnatedResult<List<GetAllProductFiltredByCategoryResult>> resultList = new();

            resultList.Data = result;

            resultList.TotalCount = await _repository.GetTotalCount();

            return resultList;
        }
    }
}
