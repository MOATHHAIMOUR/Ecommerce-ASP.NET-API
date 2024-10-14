using Ecommerce.Api.Controllers.Base;
using Ecommerce.Application.Features.Product.Queries.GetAllProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Api.AppMetaData.Route;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : AppController(mediator)
    {
        [HttpGet(ProductRouting.GetProductPaginatedList)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts([FromQuery] int PageNumer, [FromQuery] int PageSize)
        {
            var response = await _mediator.Send(new GetAllProductsQuery(PageNumer, PageSize));

            return NewResult(response);
        }
    }
}
