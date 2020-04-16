using Shop.Domain.Shared.ValueObjects;

namespace Shop.Domain.Backoffice.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string zipCode)
        {
            ZipCode = zipCode;
        }

        public string ZipCode { get; private set; }
    }
}