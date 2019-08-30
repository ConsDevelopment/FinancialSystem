using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.Enums
{
    public enum StatusType {
        Request,
        Review,
        Approved,
		Rejected,
		Cancelled,
		Ordered,
		Processed,
		Shipped,
		Delivered,
		PartialAppoved,
		PartialDelivered
    }
}