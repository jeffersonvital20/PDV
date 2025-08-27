using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using PDVAplication.Domain.Exceptions;

namespace PDVAplication.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDVControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        public PDVControllerBase(IMediator mediator) => _mediator = mediator;

        protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, var result, _) => Ok(result),
                (_, _, var error) => HandleError(error)
            };

        protected async Task<IActionResult> SendRequest(IRequest<Result> request, int statusCode = 200)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, _) => Ok(statusCode),
                (_, var error) => HandleError(error)
            };

        private IActionResult HandleError(Exception error)
            => error switch
            {
                PDVAplicationValidatorException exception => BadRequest(exception.Errors),
                _ => BadRequest(new Result(error))
            };
    }
}
