using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class OrderStatusSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<OrderStatus>()
            {
                new OrderStatus
                {
                    Code = OrderStatuses.Canceled
                },
                new OrderStatus
                {
                    Code = OrderStatuses.Confirmed
                },
                new OrderStatus
                {
                    Code = OrderStatuses.Delivered
                },
                new OrderStatus
                {
                    Code = OrderStatuses.Finished
                },
                new OrderStatus
                {
                    Code = OrderStatuses.Shipping
                },
                new OrderStatus
                {
                    Code = OrderStatuses.Unconfirmed
                }
            });
        }
    }
}
