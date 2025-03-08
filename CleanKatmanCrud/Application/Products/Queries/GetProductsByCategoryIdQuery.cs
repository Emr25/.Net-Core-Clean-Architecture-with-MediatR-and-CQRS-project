using Application.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductsByCategoryIdQuery : IRequest <IEnumerable<ProductDto>>
    {
        public int CategoryId { get; set; }

    }
}
