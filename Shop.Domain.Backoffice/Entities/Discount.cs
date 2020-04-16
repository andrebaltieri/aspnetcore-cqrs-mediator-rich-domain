using System;
using Shop.Domain.Shared.Entities;

namespace Shop.Domain.Backoffice.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal price, DateTime? expireDate)
        {
            Price = price;
            ExpireDate = expireDate;
            StillValid = true;
        }

        public decimal Price { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool StillValid { get; private set; }
    }
}