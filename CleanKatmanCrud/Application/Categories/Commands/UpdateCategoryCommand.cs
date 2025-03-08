using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
