using System;
using System.Collections.Generic;

namespace ContosoUniversity.SharedKernel.Application
{
    public class InvalidCommandException : Exception
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
