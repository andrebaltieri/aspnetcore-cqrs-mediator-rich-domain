using System;
using System.Collections.Generic;
using Shop.Domain.Backoffice.Enums;
using Shop.Domain.Shared.Entities;

namespace Shop.Domain.Backoffice.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer, Discount discount, decimal deliveryFee, string notes)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Discount = discount;
            DeliveryFee = deliveryFee;
            Notes = notes;
            Items = new Dictionary<Guid, decimal>();
            Status = EOrderStatus.WaitingPayment;
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public Discount Discount { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public IDictionary<Guid, decimal> Items { get; private set; }
        public decimal Total => CalculateTotal();
        public string Notes { get; private set; }
        public EOrderStatus Status { get; set; }
        public Payment Payment { get; private set; }

        public void AddItems(IDictionary<Guid, decimal> items)
        {
            Items = items;
            LastUpdateDate = DateTime.Now;
        }

        public decimal CalculateTotal()
        {
            var total = 0M;
            foreach (var item in Items)
                total += item.Value;

            return (total + DeliveryFee) - Discount.Price;
        }

        public void Pay(Payment payment)
        {
            // Só paga se o pagamento foi realizado com sucesso
            Payment = payment;
            Status = EOrderStatus.Paid;
            LastUpdateDate = DateTime.Now;
        }

        public void Cancel(string notes)
        {
            // Só cancela se o pedido ainda não saiu para entre

            // Se houver pagamento, faz estorno
            Payment.Rollback();

            Status = EOrderStatus.Canceled;
            Notes = notes;
            LastUpdateDate = DateTime.Now;
        }

        public void StartDelivery()
        {
            Status = EOrderStatus.InTransit;
            LastUpdateDate = DateTime.Now;
        }

        public void Complete()
        {
            Status = EOrderStatus.Completed;
            LastUpdateDate = DateTime.Now;
        }

        public void OnCanceled(string notes)
        {
            // Enviar E-mail
        }

        public void OnStartDelivery()
        {
            // Enviar E-mail
        }

        public void OnDelivered()
        {
            // Enviar E-mail
        }
    }
}