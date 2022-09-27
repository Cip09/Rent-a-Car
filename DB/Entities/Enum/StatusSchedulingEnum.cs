using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities.Enum
{
    public enum StatusSchedulingEnum
    {
        None = 0,
        SchedulingApprovedByAdmin = 1,
        SchedulingStart = 2,
        SchedulingEnd = 3,
        SchedulingDecline = 4,
        SchedulingRetreatTemporary = 5,
        SchedulingRetreatPermanen = 6,
        ScheduliingRetreatTemporaryApproved = 7,
        SchedulingRetreatPermanentApproved = 8

    }
}
