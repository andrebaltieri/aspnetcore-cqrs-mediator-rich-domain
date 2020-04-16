using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Backoffice.Commands.CustomerCommands.Requests;
using Shop.Domain.Backoffice.Commands.CustomerCommands.Responses;
using Shop.Domain.Backoffice.Entities;
using Shop.Domain.Backoffice.Repositories;
using Shop.Domain.Backoffice.ValueObjects;
using Shop.Domain.Shared.Commands.Responses;
using Shop.Domain.Shared.Handlers;

namespace Shop.Domain.Backoffice.Handlers.CustomerHandlers
{
    public class CreateCustomerHandler : CommandHandler, IRequestHandler<CreateCustomerRequest, CommandResponse>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            // Verifica se E-mail já existe
            var emailExists = await _repository.Exists(request.Email);
            if (emailExists)
                return BadRequestResponse(null, "Este E-mail já está cadastrado");

            // Gera a entidade
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var billingAddress = new Address(request.BillingZipCode);
            var shippingAddress = new Address(request.ShippingZipCode);
            var customer = new Customer(name, email, billingAddress, shippingAddress);

            // Consolida as notificações
            AddNotifications(name, email, billingAddress, shippingAddress, customer);

            // Cadastra
            await _repository.Save(customer);

            // Dispara o evento de cliente cadastrado


            // Retorna os dados
            var data = new CreateCustomerResponse("Andre", "Baltieri", "andre@Balta.io", "13411080", "13403151");
            return CreateResponse(data, "Cliente cadastrado com sucesso!");
        }
    }
}