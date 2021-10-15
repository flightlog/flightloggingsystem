using FLS.AuditLogging;
using FLS.Common.Validators;
using FLS.Data.WebApi.Reservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Server.Data.DbEntities
{
    public class ReservationType : IMetadata, IClubData, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationTypeId { get; set; }

        [IsNotEmpty]
        public Guid ClubId { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public ReservationKind ReservationKind { get; set; }

        [Required]
        [StringLength(100)]
        public string ReservationTypeName { get; set; }

        public bool IsInstructorRequired { get; set; }

        public bool IsMaintenance { get; set; }

        public bool IsActive { get; set; }

        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets FlightTypeId if reservation type is referencing to a FlightType.
        /// </summary>
        public Guid? FlightTypeId { get; set; }

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

        public virtual Club Club { get; set; }
    }
}
