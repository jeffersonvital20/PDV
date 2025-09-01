using MediatR;
using Microsoft.AspNetCore.Mvc;
using PDVAplication.Controllers.Base;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using PDVAplication.Domain.Requests.Command.SaleCommands;
using PDVAplication.Domain.Requests.Query.ProductQuery;
using PDVAplication.Domain.Requests.Query.SaleQuery;
using PDVAplication.Shared.ViewModel.Product;
using PDVAplication.Shared.ViewModel.Sale;

namespace PDVAplication.Controllers
{
    public class SaleController : PDVControllerBase
    {
        public SaleController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("getById")]
        public Task<IActionResult> GetById([FromQuery] Guid id) => SendRequest(new SaleGetByIdQuery(id));

        [HttpGet("getAll")]
        public Task<IActionResult> GetAll()
            => SendRequest(new SaleGetAllQuery());

        [HttpPost("create")]
        public Task<IActionResult> Create([FromBody] InitialSaleViewModel Sale)
            => SendRequest(new CreateSaleCommand(Sale));

        [HttpPost("updateProduct")]
        public Task<IActionResult> UpdateProduct([FromBody] UpdateProductSaleViewModel Sale)
            => SendRequest(new UpdateProductSaleCommand(Sale));

        [HttpPost("FinishSale")]
        public Task<IActionResult> FinishSale([FromBody] StatusSaleProductViewModel id)
            => SendRequest(new FinishProductSaleCommand(id));

        [HttpDelete("deleteProduct")]
        public Task<IActionResult> DeleteProduct([FromQuery] delectproductSaleViewModel id)
            => SendRequest(new DeleteProductSaleCommand(id));

        [HttpPatch("cancelSale")]
        public Task<IActionResult> CancalSale([FromBody] StatusSaleProductViewModel id)
            => SendRequest(new CancelSaleCommand(id));

        
    }
}
