using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Data.WebApi.Airports
{
    public class AirportOverview
    {
        public Guid AirportId { get; set; }

        public string AirportName { get; set; }

        public string IcaoCode { get; set; }
        
        public string AirportTypeName { get; set; }

        public string CountryName { get; set; }

        public string Elevation { get; set; }
        
        public string AirportFrequency { get; set; }
    }
}
