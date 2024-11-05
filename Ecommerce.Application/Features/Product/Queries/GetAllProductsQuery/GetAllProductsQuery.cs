using Ecommerce.Application.Common.ApiResponse;
using Ecommerce.Application.DTOs.ProductDtos;
using MediatR;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<ApiResponse<List<ProductDto>>>
    {
        public GetAllProductsQuery(int pageNumber, int pageCountet, Dictionary<string, string> filters, Dictionary<string, string> orders)
        {
            PageNumber = pageNumber;
            PageSize = pageCountet;
            Filters = filters;
            Orders = orders;
        }

        public int PageNumber { get; set; }
        public int PageSize { set; get; }    

        public Dictionary<string,string> Filters { get; set; }
        public Dictionary<string,string> Orders { get; set; }

    }
}
