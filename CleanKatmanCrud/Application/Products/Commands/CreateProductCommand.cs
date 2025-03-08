using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
