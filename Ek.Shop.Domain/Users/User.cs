using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.Products;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ek.Shop.Domain.Users
{
    public class User : IdentityUser<int>
    {
        // Kaip nors reiktu ideti ir company user, kad nedublikuoti tik imones objektu
        public User()
        {
            Baskets = new HashSet<Basket>();
            ProductRatings = new HashSet<ProductRating>();
            ProductReviews = new HashSet<ProductReview>();
            Orders = new HashSet<Order>();
        }

        public string Address { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }

        public string City { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string CompanyVat { get; set; }

        public DateTime Created { get; set; }

        // Gal net nereikalingas! Uztektu ir tiktais last login ip
        public string CreatedIp { get; set; }

        public bool IsBuyerCompany { get; set; }

        public DateTime LastLogin { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int? PostCode { get; set; }

        public virtual ICollection<ProductRating> ProductRatings { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }

        public IList<string> Roles { get; set; }
    }
}
