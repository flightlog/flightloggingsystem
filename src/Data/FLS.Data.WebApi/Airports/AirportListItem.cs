using System;

namespace FLS.Data.WebApi.Airports
{
    public class AirportListItem
    {
        public Guid AirportId { get; set; }

        public string CountryCode { get; set; }

        public string IcaoCode { get; set; }

        public string AirportName { get; set; }
    }
}
