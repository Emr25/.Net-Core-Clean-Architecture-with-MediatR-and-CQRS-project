using Application.Products.Commands;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Unit>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductCommandHandler(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteAsync(request.ProductId);
            return Unit.Value;
        }
    }
}
