using FLS.AuditLogging;
using FLS.Data.WebApi.Settings;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace FLS.Server.Data.DbEntities
{
    public class Setting : IMetadata, IAuditable
    {
        public Guid SettingId { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public SettingScope SettingScope { get; set; }

        /// <summary>
        /// Gets or sets ClubId
        /// <remarks>ClubId will be set, when SettingScope = Club, otherwise null</remarks>
        /// </summary>
        public Guid? ClubId { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// <remarks>UserId will be set, when SettingScope = User, otherwise null</remarks>
        /// </summary>
        public Guid? UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }

        public virtual Club Club { get; set; }

        public virtual User User { get; set; }

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

        public static Expression<Func<Setting, SettingDetails>> ToSettingDetails
        {
            get
            {
                return x => new SettingDetails()
                {
                    SettingKey = x.SettingKey,
                    SettingValue = x.SettingValue,
                    SettingScope = x.SettingScope
                };
            }
        }
    }
}
