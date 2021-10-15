using FLS.AuditLogging;
using FLS.Common.Validators;
using FLS.Data.WebApi.Accounting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLS.Server.Data.DbEntities
{
    public class AccountingRuleFilter : IMetadata, IClubData, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountingRuleFilterId { get; set; }

        [IsNotEmpty]
        public Guid ClubId { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public AccountingRuleFilterType AccountingRuleFilterType { get; set; }

        [StringLength(250)]
        public string RuleFilterName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the article or recipient target for this rule
        /// </summary>
        public string Target { get; set; }

        //TODO: Implement logic together with SortIndicator
        //public bool StopRuleEngineWhenRuleApplied { get; set; }
        //public int SortIndicator { get; set; }

        public bool IsRuleForGliderFlights { get; set; }
        public bool IsRuleForTowingFlights { get; set; }

        public bool IsRuleForMotorFlights { get; set; }

        public bool UseRuleForAllAircraftsExceptListed { get; set; }
        public string MatchedAircraftImmatriculations { get; set; }

        public bool UseRuleForAllStartTypesExceptListed { get; set; }

        public string MatchedStartTypes { get; set; }

        public bool UseRuleForAllFlightTypesExceptListed { get; set; }

        //[Column("MatchedFlightTypeCodes")]
        public string MatchedFlightTypeCodes { get; set; }

        public bool ExtendMatchingFlightTypeCodesToGliderAndTowFlight { get; set; }

        public bool UseRuleForAllStartAirportsExceptListed { get; set; }
        
        /// <summary>
        /// Get or sets the start airport ICAO codes for this rule filter
        /// </summary>
        public string MatchedStartAirports { get; set; }

        public bool UseRuleForAllLdgAirportsExceptListed { get; set; }

        /// <summary>
        /// Get or sets the landing airport ICAO codes for this rule filter
        /// </summary>
        public string MatchedLdgAirports { get; set; }

        public bool UseRuleForAllClubMemberNumbersExceptListed { get; set; }

        public string MatchedClubMemberNumbers { get; set; }

        public bool UseRuleForAllFlightCrewTypesExceptListed { get; set; }

        public string MatchedFlightCrewTypes { get; set; }

        public bool UseRuleForAllAircraftsOnHomebaseExceptListed { get; set; }

        public string MatchedAircraftsHomebase { get; set; }

        public bool UseRuleForAllMemberStatesExceptListed { get; set; }

        public string MatchedMemberStates { get; set; }

        public bool UseRuleForAllPersonCategoriesExceptListed { get; set; }

        public string MatchedPersonCategories { get; set; }

        public bool IsChargedToClubInternal { get; set; }

        public int? MinFlightTimeInSecondsMatchingValue { get; set; }

        public int? MaxFlightTimeInSecondsMatchingValue { get; set; }

        public int? MinEngineTimeInSecondsMatchingValue { get; set; }

        public int? MaxEngineTimeInSecondsMatchingValue { get; set; }

        public bool IncludeThresholdText { get; set; }

        [StringLength(250)]
        public string ThresholdText { get; set; }

        public bool IncludeFlightTypeName { get; set; }

        public bool NoLandingTaxForGlider { get; set; }
        public bool NoLandingTaxForTowingAircraft { get; set; }
        public bool NoLandingTaxForAircraft { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public AccountingUnitType AccountingUnitType { get; set; }


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
