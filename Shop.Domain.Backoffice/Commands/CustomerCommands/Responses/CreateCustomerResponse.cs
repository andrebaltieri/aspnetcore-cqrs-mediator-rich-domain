using Shop.Domain.Shared.Commands.Responses;

namespace Shop.Domain.Backoffice.Commands.CustomerCommands.Responses
{
    public class CreateCustomerResponse
    {
        public CreateCustomerResponse(string firstName, string lastName, string email, string billingZipCode, string shippingZipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BillingZipCode = billingZipCode;
            ShippingZipCode = shippingZipCode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BillingZipCode { get; set; }
        public string ShippingZipCode { get; set; }
    }
}