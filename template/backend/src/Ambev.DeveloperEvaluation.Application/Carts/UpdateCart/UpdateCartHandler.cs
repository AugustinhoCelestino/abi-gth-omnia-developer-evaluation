using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _repository = cartRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cartToUpdate = _mapper.Map<Cart>(command);

            var cartToCheckIfExists = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (cartToCheckIfExists == null)
                throw new KeyNotFoundException($"Cart with ID {command.Id} not found");

            Cart updatedCart = await _repository.UpdateAsync(cartToUpdate, cancellationToken);
            var result = _mapper.Map<UpdateCartResult>(updatedCart);

            return result;
        }
    }
}
