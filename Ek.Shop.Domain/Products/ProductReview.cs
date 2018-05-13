using Ek.Shop.Domain.Users;
using System;

namespace Ek.Shop.Domain.Products
{
    public class ProductReview : Entity
    {
        public ProductReview()
        { }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public bool IsConfirmed { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}
