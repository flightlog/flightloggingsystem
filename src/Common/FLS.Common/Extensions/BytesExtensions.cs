using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Common.Extensions
{
    public static class BytesExtensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("x2").ToLower());

            return sb.ToString();
        }
    }
}

