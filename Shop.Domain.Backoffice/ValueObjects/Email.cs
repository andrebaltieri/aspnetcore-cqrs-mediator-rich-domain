using Shop.Domain.Shared.ValueObjects;

namespace Shop.Domain.Backoffice.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}