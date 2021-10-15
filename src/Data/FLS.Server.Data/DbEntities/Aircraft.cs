using FLS.AuditLogging;
using FLS.Data.WebApi.Aircraft;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    [Index("Immatriculation", IsUnique = true)]
    public class Aircraft : IMetadata, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AircraftId { get; set; }

        [Required]
        [StringLength(15)]
        public string Immatriculation { get; set; }

        [StringLength(5)]
        public string CompetitionSign { get; set; }

        [StringLength(100)]
        public string ManufacturerName { get; set; }

        [StringLength(100)]
        public string AircraftModel { get; set; }

        public int? NrOfSeats { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public AircraftType AircraftType { get; set; }

        public bool? IsTowingRequired { get; set; }

        public bool? IsTowingAircraft { get; set; }

        /// <summary>
        /// Gets or sets the device Id (e.g. Flarm ID, other tracker device id) for tracking in OGN or other tracking systems
        /// </summary>
        [StringLength(10)]
        public string DeviceId { get; set; }

        [StringLength(50)]
        public string AircraftSerialNumber { get; set; }

        public int? YearOfManufacture { get; set; }

        [StringLength(1)]
        public string NoiseClass { get; set; }

        public string NoiseLevel { get; set; }

        public int? MTOM { get; set; }

        #region Metadata Properties

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(Constants.UserNameMaxLength)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        [StringLength(Constants.UserNameMaxLength)]
        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        #endregion Metadata Properties
    }
}
