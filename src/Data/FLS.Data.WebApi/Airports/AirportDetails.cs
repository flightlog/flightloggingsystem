using System;
using System.ComponentModel.DataAnnotations;

namespace FLS.Data.WebApi.Airports
{
    public class AirportDetails : ISecurable
    {
        public Guid AirportId { get; set; }

        [Required]
        [StringLength(100)]
        public string AirportName { get; set; }

        [Required]
        [StringLength(10)]
        public string IcaoCode { get; set; }

        public int CountryId { get; set; }

        [Required]
        public AirportType AirportType { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? ElevationInM { get; set; }

        public bool CanUpdateRecord { get; set; }
        public bool CanDeleteRecord { get; set; }
    }
}
