using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResult>
    {
        private readonly IProductRepository _repository;

        public GetAllCategoriesHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoriesResult> Handle(GetAllCategoriesCommand command, CancellationToken cancellationToken)
        {
            var resultList = await _repository.GetAllCategories(cancellationToken);

            var result = new GetAllCategoriesResult{ Category = resultList};
            return result;
        }
    }
}
