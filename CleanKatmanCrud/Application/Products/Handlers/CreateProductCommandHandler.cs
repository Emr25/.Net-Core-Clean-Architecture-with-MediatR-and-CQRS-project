using Application.Categories.Commands;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public  async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Name = request.Name, CategoryId = request.CategoryId };
            await productRepository.AddAsync(product);
            return product.ProductId;
        }
    }
}
