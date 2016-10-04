using System;
using System.Runtime.Serialization;

namespace CalculatorService
{
    [Serializable]
    public class NotNumberException : Exception
    {
        public NotNumberException()
        {
        }

        public NotNumberException(string message) : base(message)
        {
        }

        public NotNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}