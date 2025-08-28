using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDVAplication.Controllers.Base;
using PDVAplication.Domain.Requests.Command;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using PDVAplication.Domain.Requests.Query;
using PDVAplication.Domain.Requests.Query.ProductQuery;
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;

namespace PDVAplication.Controllers
{
    public class ProductController : PDVControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)  {}

        [HttpGet("getById")]
        public Task<IActionResult> GetById([FromQuery] Guid id) => SendRequest(new ProductGetByIdQuery(id));

        [HttpGet("getAll")]
        public Task<IActionResult> GetAll()
            => SendRequest(new ProductGetAllQuery());

        [HttpPost("create")]
        public Task<IActionResult> Create([FromBody] ProductViewModel Customer)
            => SendRequest(new CreateProductCommand(Customer));

        [HttpPatch("update")]
        public Task<IActionResult> Update([FromBody] ProductViewModel input)
            => SendRequest(new UpdateProductCommand(input));

        [HttpDelete("delete")]
        public Task<IActionResult> Delete([FromQuery] Guid id)
            => SendRequest(new DeleteProductCommand(id));
    }
}
