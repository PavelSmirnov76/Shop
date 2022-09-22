using Microsoft.AspNetCore.Identity;

namespace Shop.Models
{
    public class User : IdentityUser
    {
        public Basket? Basket { get; set; }
    }
}
