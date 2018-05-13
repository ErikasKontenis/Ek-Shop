using Ek.Shop.Application.Baskets;
using System;
using System.Linq;

namespace Ek.Shop.Application.Orders
{
    public class OrderDto
    {
        public string Address { get; set; }

        public BasketDto Basket { get; set; }

        public string City { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string CompanyVat { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public bool IsBuyerCompany { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string OrderStatus { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentMethodType { get; set; }

        public string PhoneNumber { get; set; }

        public int? PostCode { get; set; }

        public string ShippingMethod { get; set; }

        public decimal? TotalPrice => Basket?.BasketItems?.Sum(o => o.GetTotalPrice());
    }
}
