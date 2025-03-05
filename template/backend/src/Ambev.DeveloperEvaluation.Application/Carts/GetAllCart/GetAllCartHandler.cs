using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    public class GetAllCartHandler : IRequestHandler<GetAllCartCommand, PagnatedResult<List<GetAllCartResult>>>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _repository = cartRepository;
            _mapper = mapper;
        }
        public async Task<PagnatedResult<List<GetAllCartResult>>> Handle(GetAllCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var orderbyLambda = OrderbyToLambda<Cart>(command.OrderBy);
            var descending = OrderbyToDescending(command.OrderBy);

            var cartsList =
                await _repository.GetAllPaginatedAsync(
                    command.PageNumber,
                    command.PageSize,
                    orderbyLambda,
                    descending,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllCartResult>>(cartsList);


            PagnatedResult<List<GetAllCartResult>> resultList = new();

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
