using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Query.SaleQuery
{
    public class SaleGetByIdQuery : IRequest<Result<SaleViewModel>>, IValidatable
    {
        public Guid Id { get; set; }
        public SaleGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
