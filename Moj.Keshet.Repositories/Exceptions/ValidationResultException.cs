using System;
using System.Collections.Generic;

namespace Moj.Keshet.Repositiories.Exceptions
{
    public class ValidationResultException : Exception
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationResultException(List<string> messages)
        {
            ErrorMessages = messages;
        }
    }
}
