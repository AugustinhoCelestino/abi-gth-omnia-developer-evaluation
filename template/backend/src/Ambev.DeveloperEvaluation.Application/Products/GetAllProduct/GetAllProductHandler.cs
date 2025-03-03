using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

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


            var orderbyLambda = OrderbyToLambda<Product>(command.OrderBy);
            var descending = OrderbyToDescending(command.OrderBy);

            var ProductsList =
                await _repository.GetAllPaginatedAsync(
                    command.PageNumber,
                    command.PageSize,
                    orderbyLambda,
                    descending,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllProductResult>>(ProductsList);

            PagnatedResult<List<GetAllProductResult>> resultList = new();

            resultList.Data = result;

            resultList.TotalCount = await _repository.GetTotalCount();

            return resultList;
        }

        private Expression<Func<T, object>> OrderbyToLambda<T>(string orderBy) where T : class
        {
            var spiltedOrder = orderBy.Split(" ");
            var propertyName = String.IsNullOrEmpty(spiltedOrder[0]) ? "Id" : spiltedOrder[0];

            var parameter = Expression.Parameter(typeof(T), "ob");
            var property = Expression.Property(parameter, propertyName);

            var convert = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(convert, parameter);
        }

        private bool OrderbyToDescending(string orderBy)
        {
            var spiltedOrder = orderBy.Split(" ");
            if (String.IsNullOrEmpty(spiltedOrder[0])) 
                return false;
            if (spiltedOrder[1] == "desc") 
                return true;

            return false;
        }
    }
}
