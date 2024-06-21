using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Exceptions
    {
        public class AuthenticationException : Exception
        {
            public AuthenticationException(string message) : base(message) { }
        }

        public class PostNotFoundException : Exception
        {
            public PostNotFoundException(string message) : base(message) { }
        }

        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message) { }
        }
    }
}
