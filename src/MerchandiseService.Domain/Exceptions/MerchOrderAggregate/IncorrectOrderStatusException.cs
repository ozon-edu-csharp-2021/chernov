using System;

namespace MerchandiseService.Domain.Exceptions.MerchOrderAggregate
{
    public class IncorrectOrderStatusException : Exception
    {
        public IncorrectOrderStatusException(string message) : base(message)
        {
            
        }
        
        public IncorrectOrderStatusException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}