using Shop.Domain.Backoffice.ValueObjects;
using Shop.Domain.Shared.Entities;

namespace Shop.Domain.Backoffice.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, Address billingAddress, Address shippingAddress)
        {
            Name = name;
            Email = email;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address ShippingAddress { get; private set; }
    }
}