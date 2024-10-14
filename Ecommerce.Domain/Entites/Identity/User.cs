using Ecommerce.Domain.Entites.Base;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entites.Identity
{
    public class User : IdentityUser<int>, IEntity
    {
        // more properties 
        public int perosnId { set; get; }
        
        // navigation properies
        public Person Person { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
