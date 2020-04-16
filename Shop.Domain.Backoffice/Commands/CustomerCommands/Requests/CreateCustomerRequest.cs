using Flunt.Validations;
using Shop.Domain.Shared.Commands.Requests;

namespace Shop.Domain.Backoffice.Commands.CustomerCommands.Requests
{
    public class CreateCustomerRequest : CommandRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BillingZipCode { get; set; }
        public string ShippingZipCode { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "FirstName", "Nome inválido (min)")
                    .HasMaxLen(FirstName, 60, "FirstName", "Nome inválido (max)")
            );
        }
    }
}