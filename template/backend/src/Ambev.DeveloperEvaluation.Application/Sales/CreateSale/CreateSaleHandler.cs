using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CreateSaleHandler(ISaleRepository SaleRepository, ICartRepository CartRepository, IMapper mapper)
        {
            _repository = SaleRepository;
            _cartRepository = CartRepository;
            _mapper = mapper;
        }
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Sale>(command);

            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            if (cart == null)
                throw new KeyNotFoundException($"Cart with ID {command.CartId} not found");

            List<CartItem>? cartItems = cart.CartItems;
            if (cartItems == null)
                throw new KeyNotFoundException($"Cart with ID {command.CartId} has no items");

            sale.CartItems = cartItems;

            Sale createdSale = await _repository.CreateAsync(sale, cancellationToken);
            var result = _mapper.Map<CreateSaleResult>(createdSale);

            return result;
        }
    }
}
