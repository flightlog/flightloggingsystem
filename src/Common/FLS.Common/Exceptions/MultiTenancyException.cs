using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Exceptions
{
    public class MultiTenancyException : Exception
    {
        public MultiTenancyException(string message)
            : base(message)
        {
        }
    }
}