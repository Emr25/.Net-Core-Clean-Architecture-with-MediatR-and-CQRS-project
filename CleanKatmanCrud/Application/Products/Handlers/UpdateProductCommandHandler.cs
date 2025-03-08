using Application.Products.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { ProductId = request.ProductId, Name = request.Name, CategoryId = request.CategoryId };
            await _productRepository.UpdateAsync(product);
            return Unit.Value;
        }
    }
}
