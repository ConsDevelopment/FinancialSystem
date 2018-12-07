using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialSystem.Utilities.Attributes;

namespace FinancialSystem.Models.Enums
{
    public enum ThumbsType 
    {

        None=0,
		[Icon(BootstrapGlyphs.thumbs_up)]
		Up = 1,
		[Icon(BootstrapGlyphs.thumbs_down)]
        Down=2

    }
}