using Ecommerce.Domain.Entites.Base;
using Ecommerce.Domain.Entites.Identity;

namespace Ecommerce.Domain.Entites
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public required string Phone { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string StreetName { get; set; }
        public required string HouseNumber { get; set; }


        public Person Person { get; set; }

    }
}
