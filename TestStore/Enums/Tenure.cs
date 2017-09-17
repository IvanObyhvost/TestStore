using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestStore.Enums
{
    public enum Tenure
    {
        Freehold,
        Leasehold,

        [Description("Share of Freehold")]
        ShareOfFreehold
    }
}