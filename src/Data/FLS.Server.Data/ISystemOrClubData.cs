using System;

namespace FLS.Server.Data
{
    public interface ISystemOrClubData
    {
        /// <summary>
        /// Guid is set when data are related to a club.
        /// Otherwise, if Guid value is null, the data are system related and might be readonly.
        /// </summary>
        Guid? ClubId { get; }
    }
}
