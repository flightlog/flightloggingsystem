using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Data.WebApi.Accounting
{
    public enum AccountingRuleFilterType
    {
        DoNotInvoiceFlight,
        RecipientRetarget,
        NoLandingTax,
        AircraftFlightTime,
        InstructorFee,
        AdditionalFuelFee,
        StartTax,
        LandingTax,
        VsfFee,
        EngineTime,
    }
}
