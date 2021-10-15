using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Data.WebApi.Club
{
    public enum ClubState
    {
        /// <summary>
        /// System used club (will not be shown in club entities)
        /// </summary>
        System = 0,

        /// <summary>
        /// Active club tenant with users
        /// </summary>
        Active = 1,

        /// <summary>
        /// Club without tenant activities and no users (just information about the club)
        /// </summary>
        Passive = 2,

        /// <summary>
        /// Club tenant which was active before
        /// </summary>
        Inactive = 3
    }
}
