using FLS.AuditLogging;
using FLS.Common.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Server.Data.DbEntities
{
    public class ClubSettings : IMetadata, IClubData, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClubSettingsId { get; set; }

        [IsNotEmpty]
        public Guid ClubId { get; set; }

        public int? DefaultStartTypeId { get; set; }

        public Guid? DefaultGliderFlightTypeId { get; set; }

        public Guid? DefaultTowFlightTypeId { get; set; }

        public Guid? DefaultMotorFlightTypeId { get; set; }

        [StringLength(250)]
        public string SendAircraftStatisticReportTo { get; set; }

        [StringLength(250)]
        public string SendPlanningDayInfoMailTo { get; set; }

        [StringLength(250)]
        public string SendDeliveryMailExportTo { get; set; }

        [StringLength(250)]
        public string SendTrialFlightRegistrationOperatorEmailTo { get; set; }

        [StringLength(250)]
        public string SendPassengerFlightRegistrationOperatorEmailTo { get; set; }

        [StringLength(250)]
        public string ReplyToEmailAddress { get; set; }

        public bool RunDeliveryCreationJob { get; set; }

        public bool RunDeliveryMailExportJob { get; set; }

        //[Column(TypeName = "datetime2")]
        //public DateTime? LastPersonSynchronisationOn { get; set; }

        //[Column(TypeName = "datetime2")]
        //public DateTime? LastDeliverySynchronisationOn { get; set; }

        //[Column(TypeName = "datetime2")]
        //public DateTime? LastArticleSynchronisationOn { get; set; }

        public bool IsClubMemberNumberReadonly { get; set; }

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
