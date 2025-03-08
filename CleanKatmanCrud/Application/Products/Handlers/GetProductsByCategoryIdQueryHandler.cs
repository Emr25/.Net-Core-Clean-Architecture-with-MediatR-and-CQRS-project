using Application.Dto;
using Application.Products.Queries;
using AutoMapper;
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
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;


        public GetProductsByCategoryIdQueryHandler(IProductRepository  _productRepository, IMapper _mapper)
        {
            productRepository = _productRepository;
            mapper = _mapper;

        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByCategoryIdAsync(request.CategoryId);
            return mapper.Map<IEnumerable<ProductDto>>(product);
        }
    }
}
