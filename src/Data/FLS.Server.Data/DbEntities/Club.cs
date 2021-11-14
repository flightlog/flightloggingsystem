using FLS.AuditLogging;
using FLS.Data.WebApi.Club;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    [Index("ClubKey", IsUnique = true)]
    public class Club : IMetadata, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClubId { get; set; }

        [Required]
        [StringLength(100)]
        public string ClubName { get; set; }

        [Required]
        [StringLength(10)]
        public string ClubKey { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public ClubState ClubState { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public int CountryId { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(30)]
        public string FaxNumber { get; set; }

        [StringLength(Constants.EmailAddressMaxLength)]
        public string EmailAddress { get; set; }

        [StringLength(100)]
        public string WebPage { get; set; }

        [StringLength(100)]
        public string Contact { get; set; }

        public Guid? HomebaseAirportId { get; set; }

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

        public virtual Airport HomebaseAirport { get; set; }
    }
}
