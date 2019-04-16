using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Controllers
{
    public enum AccessLevel
    {
        SignedOut=-1,
        Any=1,
        User=2,
        TeamLeader=3
    }
}