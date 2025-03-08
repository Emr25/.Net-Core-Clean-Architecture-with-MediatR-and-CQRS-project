using Application.Dto;
using Application.Products.Commands;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult <ProductDto> > GetProduct(int id)
        {
           var query = new GetProductQuery { ProductId = id };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable <ProductDto> > > GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var query = new GetProductsByCategoryIdQuery { CategoryId = categoryId };
            var result = await mediator.Send(query);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { ProductId = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
