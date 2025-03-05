using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetByIdCart
{
    public class GetByIdCartHandler : IRequestHandler<GetByIdCartCommand, GetByIdCartResult>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _repository = cartRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdCartResult> Handle(GetByIdCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetByIdCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (cart == null)
                throw new KeyNotFoundException($"ID {command.Id} not found");

            return _mapper.Map<GetByIdCartResult>(cart);
        }
    }
}
