using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productToUpdate = _mapper.Map<Product>(command);

            var productToCheckIfExists = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (productToCheckIfExists == null)
                throw new KeyNotFoundException($"Product with ID {command.Id} not found");

            var updateProduct = await _repository.UpdateAsync(productToUpdate, cancellationToken);
            var result = _mapper.Map<UpdateProductResult>(updateProduct);

            return result;
        }
    }
}
