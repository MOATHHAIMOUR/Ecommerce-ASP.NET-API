using Ecommerce.Application.Services.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Product.Command.AddProductCommand
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private IProductServices _productServices;

        public AddProductCommandHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }

}
