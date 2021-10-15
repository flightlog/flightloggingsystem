using FLS.AuditLogging;
using FLS.Common.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    public class Article : IMetadata, IClubData, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ArticleId { get; set; }

        [IsNotEmpty]
        public Guid ClubId { get; set; }

        [Required]
        [StringLength(50)]
        public string ArticleNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string ArticleName { get; set; }

        [StringLength(250)]
        public string ArticleInfo { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

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
