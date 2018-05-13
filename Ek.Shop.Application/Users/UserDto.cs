using System;
using System.Collections.Generic;

namespace Ek.Shop.Application.ApplicationUser
{
    public class UserDto
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string CompanyVat { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public bool IsBuyerCompany { get; set; }

        public DateTime LastLogin { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int? PostCode { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }
}
