﻿using FLS.AuditLogging;
using FLS.Data.WebApi.Airports;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    [Index("IcaoCode", IsUnique = true)]
    public class Airport : IMetadata, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AirportId { get; set; }

        [Required]
        [StringLength(100)]
        public string AirportName { get; set; }

        [Required]
        [StringLength(10)]
        public string IcaoCode { get; set; }

        public int CountryId { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public AirportType AirportType { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? ElevationInM { get; set; }

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

        public virtual Country Country { get; set; }
    }
}