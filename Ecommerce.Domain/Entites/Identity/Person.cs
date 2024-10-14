using Ecommerce.Domain.Entites.Base;

namespace Ecommerce.Domain.Entites.Identity
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string LastName { get; set; }


        public ICollection<Address> Addresses { get; set; }

    }
}
