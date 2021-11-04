using System;

namespace MerchandiseService.Domain.Exceptions.MerchOrderAggregate
{
    public class ClothingSizeException : Exception
    {
        public ClothingSizeException(string message) : base(message)
        {
            
        }
        
        public ClothingSizeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}