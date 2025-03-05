using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }
        public async Task<DeleteUserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {command.Id} not found");

            var success = await _repository.DeleteAsync(user, cancellationToken);

            return new DeleteUserResult { Success = true };
        }
    }
}
