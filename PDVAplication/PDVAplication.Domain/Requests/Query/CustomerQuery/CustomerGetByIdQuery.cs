using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Query.CustomerQuery
{
    public class CustomerGetByIdQuery : IRequest<Result<CustomerByIdViewModel>>, IValidatable
    {
        public Guid Id { get; set; }
        public CustomerGetByIdQuery(Guid Id) => this.Id = Id;
        
    }
}