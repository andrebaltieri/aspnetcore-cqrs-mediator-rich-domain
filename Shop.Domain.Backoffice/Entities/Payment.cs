using System;
using Shop.Domain.Shared.Entities;

namespace Shop.Domain.Backoffice.Entities
{
    public class Payment : Entity
    {
        public delegate void OnSuccess();

        public Payment(Guid orderId, decimal value, string notes, bool success)
        {
            OrderId = orderId;
            Value = value;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Notes = notes;
            Success = success;
        }

        public Guid OrderId { get; private set; }
        public decimal Value { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public string Notes { get; private set; }
        public bool Success { get; private set; }


        public void Rollback()
        {
            Success = false;
            Notes = "Realizado estorno";
            LastUpdateDate = DateTime.Now;
        }
    }
}