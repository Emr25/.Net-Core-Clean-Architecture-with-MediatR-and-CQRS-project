using Application.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Categories.Queries
{
    public class GetCategoryQuery : IRequest<CategoryDto>
    {
        public int CategoryId { get; set; }
    }
}
