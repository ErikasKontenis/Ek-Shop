using Microsoft.AspNetCore.Identity;

namespace Ek.Shop.Domain.Identities
{
    public class IdentityRole : IdentityRole<int>
    {
        public IdentityRole()
        {

        }


        public string Description { get; set; }
    }
}
