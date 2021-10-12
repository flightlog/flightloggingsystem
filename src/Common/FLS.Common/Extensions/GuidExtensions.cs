using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks if the Guid? has a value and is not empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns true, if the Guid has a value and is not empty</returns>
        public static bool HasValidGuid(this Guid? value)
        {
            return value.HasValue && value.Value != Guid.Empty;
        }
    }
}
