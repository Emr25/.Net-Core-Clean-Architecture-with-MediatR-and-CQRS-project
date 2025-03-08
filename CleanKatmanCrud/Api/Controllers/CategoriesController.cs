using Application.Categories.Commands;
using Application.Categories.Queries;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator _mediator)
        {
            mediator = _mediator;
        }


        [HttpPost]
        public async Task<ActionResult<int> > CreateCategory(CreateCategoryCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var query = new GetCategoryQuery  { CategoryId = id };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable <CategoryDto> >>GetAllCategories() 
        {
          var query = new GetAllCategoriesQuery();
          var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, UpdateCategoryCommand command)
        {
            if (id != command.CategoryId)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { CategoryId = id };
            await mediator.Send(command);
            return NoContent();
        }



    }
}
