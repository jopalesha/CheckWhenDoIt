using System;

namespace Jopalesha.CheckWhenDoIt.Tests
{
    internal class CustomException : Exception
    {
        public CustomException() : this("error")
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}