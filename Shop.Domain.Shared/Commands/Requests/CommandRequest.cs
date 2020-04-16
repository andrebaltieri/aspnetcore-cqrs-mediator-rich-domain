using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Shop.Domain.Shared.Commands.Responses;

namespace Shop.Domain.Shared.Commands.Requests
{
    public abstract class CommandRequest : Notifiable, IRequest<CommandResponse>, IValidatable
    {
        public virtual void Validate()
        {

        }
    }
}