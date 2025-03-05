using Ambev.DeveloperEvaluation.Application.Model;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, PagnatedResult<List<GetAllUserResult>>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public GetAllUserHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _repository = UserRepository;
            _mapper = mapper;
        }
        public async Task<PagnatedResult<List<GetAllUserResult>>> Handle(GetAllUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);


            var orderbyLambda = OrderbyToLambda<User>(command.OrderBy);
            var descending = OrderbyToDescending(command.OrderBy);

            var UsersList =
                await _repository.GetAllPaginatedAsync(
                    command.PageNumber,
                    command.PageSize,
                    orderbyLambda,
                    descending,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllUserResult>>(UsersList);

            PagnatedResult<List<GetAllUserResult>> resultList = new()
            {
                Data = result,

                TotalCount = await _repository.GetTotalCount()
            };

            return resultList;
        }

        private static Expression<Func<T, object>> OrderbyToLambda<T>(string orderBy) where T : class
        {
            var spiltedOrder = orderBy.Split(" ");
            var propertyName = string.IsNullOrEmpty(spiltedOrder[0]) ? "Id" : spiltedOrder[0];

            var parameter = Expression.Parameter(typeof(T), "ob");
            var property = Expression.Property(parameter, propertyName);

            var convert = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(convert, parameter);
        }

        private static bool OrderbyToDescending(string orderBy)
        {
            var spiltedOrder = orderBy.Split(" ");
            if (string.IsNullOrEmpty(spiltedOrder[0]))
                return false;
            if (spiltedOrder[1] == "desc")
                return true;

            return false;
        }
    }
}
