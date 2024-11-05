using Ecommerce.Api.Controllers.Base;
using Ecommerce.Api.Helpers;
using Ecommerce.Application.Features.Product.Queries.GetAllProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Api.AppMetaData.Route;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class ProductController(IMediator mediator) : AppController(mediator)
    {
        [HttpGet(ProductRouting.GetProductPaginatedList)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts(
            [FromQuery] string filters,
            [FromQuery] string ordring,
            [FromQuery] int PageNumer,
            [FromQuery] int PageSize)
        {

            Dictionary<string, string> filterDic = Helper.BuildDic(filters);
            Dictionary<string, string> orderDic = Helper.BuildDic(ordring);


            var response = await _mediator.Send(new GetAllProductsQuery(PageNumer,PageSize, filterDic, orderDic));

            return NewResult(response);
        }
    }
}
