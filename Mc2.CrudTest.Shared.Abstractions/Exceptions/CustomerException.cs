using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Abstractions.Exceptions
{
    public abstract class CustomerException :Exception
    {
        protected CustomerException(string message) : base(message){ }
    }
}
