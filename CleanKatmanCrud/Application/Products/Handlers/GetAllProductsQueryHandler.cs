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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;


        public GetAllProductsQueryHandler(IProductRepository  _productRepository , IMapper _mapper)
        {
            productRepository = _productRepository;
            mapper = _mapper;

        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
