using System.Data;

namespace Ecommerce.Api.AppMetaData
{
    public class Route
    {

        public const string Root = "Api";
        public const string Version = "v1";
        public const string Rule = Root + "/" + Version + "/";

        public static class CrudOperations
        {
            public const string GetById = "{Id}"; // Consider more specific naming
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
        }

        public static class ProductRouting
        {
            public const string prefix = Rule + "Product/";

            public const string GetProductPaginatedList = prefix + "/" + "GetAllProducts";


        }




    }
}
