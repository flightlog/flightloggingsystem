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
    public class Reservation : IMetadata, IClubData, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationId { get; set; }

        [IsNotEmpty]
        public Guid ClubId { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public ReservationKind ReservationKind { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Start { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime End { get; set; }

        public bool IsAllDayReservation { get; set; }

        public Guid? PilotPersonId { get; set; }
        
        public Guid AircraftId { get; set; }
        public Guid LocationId { get; set; }
        public Guid? SecondCrewPersonId { get; set; }
        public Guid ReservationTypeId { get; set; }
        public string Remarks { get; set; }

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
