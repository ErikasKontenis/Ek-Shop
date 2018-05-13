using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Transactions;
using Ek.Shop.Domain.Users;
using Ek.Shop.Domain.Vouchers;
using System;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Orders
{
    public class Order : Entity
    {
        public Order()
        {
            Characteristics = new HashSet<OrderCharacteristic>();
        }

        public string Address { get; set; }

        public Basket Basket { get; set; }

        public int BasketId { get; set; }

        public string City { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string CompanyVat { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Email { get; set; }

        public bool IsBuyerCompany { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int OrderStatusId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethodType PaymentMethodType { get; set; }

        public int? PaymentMethodTypeId { get; set; }

        public string PhoneNumber { get; set; }

        public int? PostCode { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public int ShippingMethodId { get; set; }

        public ICollection<OrderCharacteristic> Characteristics { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public virtual Voucher Voucher { get; set; }

        public int? VoucherId { get; set; }
    }
}
