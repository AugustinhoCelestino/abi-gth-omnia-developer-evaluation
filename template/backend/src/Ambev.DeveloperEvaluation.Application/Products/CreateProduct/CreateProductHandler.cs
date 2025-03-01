using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Product = _mapper.Map<Product>(command);

            var createdProduct = await _repository.CreateAsync(Product, cancellationToken);
            var result = _mapper.Map<CreateProductResult>(createdProduct);

            return result;
        }
    }
}
