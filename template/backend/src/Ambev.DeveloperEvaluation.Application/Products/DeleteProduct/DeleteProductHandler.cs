using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public DeleteProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {command.Id} not found");

            var success = await _repository.DeleteAsync(product, cancellationToken);
            
            return new DeleteProductResult { Success = true };
        }
    }
}
