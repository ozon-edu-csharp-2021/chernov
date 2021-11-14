using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Email : ValueObject
    {
        public string Value;

        private Email(string emailString)
            => Value = emailString;

        public static Email Create(string emailString)
        {
            if (IsValidEmail(emailString))
            {
                return new Email(emailString);
            }
            throw new InvalidEmailException($"Email is invalid: {emailString}");
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        
        private static bool IsValidEmail(string emailString)
            => Regex.IsMatch(emailString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}