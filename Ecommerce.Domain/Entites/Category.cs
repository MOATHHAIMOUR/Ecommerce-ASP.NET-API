using Ecommerce.Domain.Entites.Base;

namespace Ecommerce.Domain.Entites
{
    public class Category : IEntity
    {
        public int Id {  get; set; }    
        public required string Name { get; set; }
        public required string Description { get; set; }



        public ICollection<Product> Products { get; set; }

    }
}
