using System;
using System.Collections.Generic;

namespace MonthlyExpenses.Api.Models
{
    public class ClientAuthenticationException : Exception
    {
        public ClientAuthenticationException(string message)
            : base(message)
        {
        }
    }
}