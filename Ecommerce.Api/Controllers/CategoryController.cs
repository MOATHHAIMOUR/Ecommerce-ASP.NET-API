using Ecommerce.Api.Controllers.Base;
using Ecommerce.Application.Features.Category.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Api.AppMetaData.Route;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class CategoryController(IMediator mediator) : AppController(mediator)
    {
       

        [HttpGet(CategoreyRouting.GetAllCategories)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {

            var response = await _mediator.Send(new GetAllCategoriesQuery());

            return NewResult(response);
        }
    }
}
