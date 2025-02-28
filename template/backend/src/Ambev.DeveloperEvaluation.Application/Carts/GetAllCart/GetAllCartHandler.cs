using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    public class GetAllCartHandler : IRequestHandler<GetAllCartCommand, GetAllCartResult>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _repository = cartRepository;
            _mapper = mapper;
        }
        public async Task<GetAllCartResult> Handle(GetAllCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //TODO: set paginated and filtering
            
            var CartsPaginated = 
                await _repository.GetAllPaginatedAsync(
                    command.PageSize, command.PageNumber, 
                    (x => x.CartId != 0), 
                    cancellationToken);

            var result = _mapper.Map<GetAllCartResult>(CartsPaginated);

            return result;
        }
    }
}
