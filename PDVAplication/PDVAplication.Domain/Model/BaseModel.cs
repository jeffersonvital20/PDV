using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }
}
