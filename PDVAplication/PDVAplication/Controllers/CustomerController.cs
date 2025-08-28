using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDVAplication.Controllers.Base;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Domain.Requests.Query.CustomerQuery;
using PDVAplication.Shared.ViewModel.Customer;

namespace PDVAplication.Controllers
{
    public class CustomerController : PDVControllerBase
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {}

        [HttpGet("getById")]
        public Task<IActionResult> GetById([FromQuery] Guid id) => SendRequest(new CustomerGetByIdQuery(id));

        [HttpGet("getAll")]
        public Task<IActionResult> GetAll()
            => SendRequest(new CustomerGetAllQuery());

        [HttpPost("create")]
        public Task<IActionResult> Create([FromBody] CustomerViewModel Customer)
            => SendRequest(new CreateCustomerCommand(Customer));

        [HttpPatch("update")]
        public Task<IActionResult> Update([FromBody] CustomerByIdViewModel input)
            => SendRequest(new UpdateCustomerCommand(input));

        [HttpDelete("delete")]
        public Task<IActionResult> Delete([FromQuery] Guid id)
            => SendRequest(new DeleteCustomerCommand(id));
    }
}
