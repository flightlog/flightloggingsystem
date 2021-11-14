using FLS.Common.Validators;
using FLS.Data.WebApi.Airports;
using FLS.Server.Data.DbEntities;

namespace FLS.Server.Data.Extensions
{
    public static class AirportDetailsExtensions
    {
		/// <summary>
		/// Mapping AirportDetails to Airport
		/// </summary>
		/// <param name="details"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static Airport ToAirport(this AirportDetails details, Airport entity = null)
		{
			details.ArgumentNotNull("details");

			if (entity == null) entity = new Airport();

			entity.AirportId = details.AirportId;
			entity.AirportName = details.AirportName;
			entity.AirportType = details.AirportType;
			entity.CountryId = details.CountryId;
			entity.ElevationInM = details.ElevationInM;
			entity.IcaoCode = details.IcaoCode;
			entity.Latitude = details.Latitude;
			entity.Longitude = details.Longitude;

			return entity;
		}
	}
}
