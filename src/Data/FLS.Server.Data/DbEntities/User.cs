using FLS.AuditLogging;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    public class User : IMetadata, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public Guid ClubId { get; set; }

        [Required]
        [StringLength(Constants.UserNameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(Constants.EmailAddressMaxLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        public Guid? PersonId { get; set; }

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

        public virtual Person Person { get; set; }
    }
}
