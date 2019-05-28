using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.Enums
{
    public enum StatusType {
        Request=201,
        Review=202,
        Approved=203,
		Rejected=204,
		Cancelled=205,
		Ordered=206,
		Processed=207,
		Shipped=208,
		Delivered=209,
		PartialAppoved=210,
		PartialDelivered=211
    }
}