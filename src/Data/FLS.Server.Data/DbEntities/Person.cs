using FLS.AuditLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Server.Data.DbEntities
{
    public class Person : IMetadata, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonId { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public Guid? CountryId { get; set; }

        [StringLength(30)]
        public string PrivatePhone { get; set; }

        [StringLength(30)]
        public string MobilePhone { get; set; }

        [StringLength(30)]
        public string BusinessPhone { get; set; }

        [StringLength(Constants.EmailAddressMaxLength)]
        public string PrivateEmailAddress { get; set; }

        [StringLength(Constants.EmailAddressMaxLength)]
        public string BusinessEmailAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public bool HasMotorPilotLicense { get; set; }

        public bool HasTowPilotLicense { get; set; }

        public bool HasGliderInstructorLicense { get; set; }

        public bool HasGliderPilotLicense { get; set; }

        public bool HasGliderPAXLicense { get; set; }

        public bool HasTMGLicense { get; set; }

        public bool HasWinchOperatorLicense { get; set; }

        public bool HasMotorInstructorLicense { get; set; }

        public bool HasPartMLicense { get; set; }

        [StringLength(20)]
        public string LicenseNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MedicalClass1ExpireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MedicalClass2ExpireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MedicalLaplExpireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GliderInstructorLicenseExpireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MotorInstructorLicenseExpireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PartMLicenseExpireDate { get; set; }

        public bool HasGliderTowingStartPermission { get; set; }

        public bool HasGliderSelfStartPermission { get; set; }

        public bool HasGliderWinchStartPermission { get; set; }

        [StringLength(250)]
        public string SpotLink { get; set; }

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
