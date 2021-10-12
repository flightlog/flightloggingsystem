using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(String entityName)
            : base($"{entityName} not found!")
        {
        }

        public EntityNotFoundException(String entityName, Guid id)
            : base($"{entityName} with Id: {id} not found!")
        {
        }

        public EntityNotFoundException(String entityName, string key)
            : base($"{entityName} with Key: {key} not found!")
        {
        }
    }
}
