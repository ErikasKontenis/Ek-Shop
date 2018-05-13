using Ek.Shop.Domain.Users;

namespace Ek.Shop.Domain.Products
{
    public class ProductRating : Entity
    {
        public ProductRating()
        { }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public int Rate { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}
