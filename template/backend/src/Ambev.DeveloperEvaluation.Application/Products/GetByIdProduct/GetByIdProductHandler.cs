using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByIdProduct
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductCommand, GetByIdProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdProductResult> Handle(GetByIdProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetByIdProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Product = await _repository.GetByIdAsync(command.Id, cancellationToken);
            if (Product == null)
                throw new KeyNotFoundException($"ID {command.Id} not found");

            return _mapper.Map<GetByIdProductResult>(Product);
        }
    }
}
