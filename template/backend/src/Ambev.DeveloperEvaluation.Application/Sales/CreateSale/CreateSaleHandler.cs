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

            var cart = await _cartRepository.FindAsync(command.CartId);
            if (cart == null)
                throw new KeyNotFoundException($"Cart with ID {command.CartId} not found");

            List<CartItem>? cartItems = cart.CartItems;
            if (cartItems == null)
                throw new KeyNotFoundException($"Cart with ID {command.CartId} has no items");

            if (cartItems.Any(x => x.Quantity > 20))
                throw new KeyNotFoundException($"Cart with ID {command.CartId} has more then 20 items");


            sale.CartItems = cartItems;
            sale.Date = DateTime.UtcNow;

            sale.ProductsSold = GenerateProductsSold(cartItems);

            Sale createdSale = await _repository.CreateAsync(sale, cancellationToken);

            var result = _mapper.Map<CreateSaleResult>(createdSale);

            result.TotalSaleAmount = result.ProductsSold.Sum(s => s.TotalAmount);

            return result;
        }

        public List<ProductsSold> GenerateProductsSold(List<CartItem> listCartItem)
        {
            var itemsSold = new List<ProductsSold>();

            foreach (var saleItem in listCartItem)
            {
                var price = saleItem.Product != null ? saleItem.Product.Price : 0;

                var discont = 0m;
                if (saleItem.Quantity >= 4 && saleItem.Quantity < 10)
                    discont = 10;
                if (saleItem.Quantity >= 10 && saleItem.Quantity < 20)
                    discont = 20;

                var totalAmount = ((price * saleItem.Quantity) * ((100 - discont) / 100));

                itemsSold.Add(new ProductsSold
                {
                    ProductId = saleItem.ProductId,
                    Quantity = saleItem.Quantity,
                    UnitPrice = price,
                    Discont = discont,
                    TotalAmount = totalAmount
                });
            }

            return itemsSold;
        }
    }
}
