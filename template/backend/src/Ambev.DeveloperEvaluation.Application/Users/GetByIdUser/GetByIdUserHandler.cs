using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetByIdUser
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserCommand, GetByIdUserResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdUserHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _repository = UserRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdUserResult> Handle(GetByIdUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetByIdUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var User = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (User == null)
                throw new KeyNotFoundException($"ID {command.Id} not found");

            return _mapper.Map<GetByIdUserResult>(User);
        }
    }
}
