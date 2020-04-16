using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Backoffice.Commands.CustomerCommands.Requests;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> Create(
            [FromBody]CreateCustomerRequest command
        )
        {
            return await BaseResult(command);
        }
    }
}