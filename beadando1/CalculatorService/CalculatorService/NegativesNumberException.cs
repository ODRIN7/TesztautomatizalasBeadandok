using System;
using System.Runtime.Serialization;

namespace CalculatorService
{
    [Serializable]
    public class NegativesNumberException : Exception
    {
        public NegativesNumberException()
        {
        }

        public NegativesNumberException(string message) : base(message)
        {
        }

        public NegativesNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativesNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}