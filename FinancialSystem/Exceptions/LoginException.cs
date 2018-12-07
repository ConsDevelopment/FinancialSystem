using FinancialSystem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Exceptions
{
    public class LoginException : RedirectException
    {
        public LoginException(String message,string redirectUrl) : base(message)
        {
            RedirectUrl = redirectUrl;
        }
        public LoginException(String redirectUrl=null) : this(ExceptionStrings.DefaultLoginException,redirectUrl)
        {
        }
    }
}