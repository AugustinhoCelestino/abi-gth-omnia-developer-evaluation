using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.PostProduct
{
    public class PostProductHandler : IRequestHandler<PostProductCommand, PostProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public PostProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<PostProductResult> Handle(PostProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new PostProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Product = _mapper.Map<Product>(command);

            var createdProduct = await _repository.CreateAsync(Product, cancellationToken);
            var result = _mapper.Map<PostProductResult>(createdProduct);

            return result;
        }
    }
}
