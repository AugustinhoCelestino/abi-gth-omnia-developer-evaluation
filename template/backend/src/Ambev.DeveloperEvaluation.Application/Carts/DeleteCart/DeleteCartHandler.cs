using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public DeleteCartHandler(ICartRepository CartRepository, IMapper mapper)
        {
            _repository = CartRepository;
            _mapper = mapper;
        }
        public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Cart = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (Cart == null)
                throw new KeyNotFoundException($"Cart with ID {command.Id} not found");

            var success = await _repository.DeleteAsync(Cart, cancellationToken);

            return new DeleteCartResult { Success = true };
        }
    }
}
