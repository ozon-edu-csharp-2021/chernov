using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        private EmployeeName Name;
        private Email Email;
        private ClothingSize ClothingSize;

        public Employee(EmployeeName name, Email email, ClothingSize clothingSize)
        {
            Name = name;
            Email = email;
            ClothingSize = clothingSize;
        }
        
        public void SetClothingSize(ClothingSize clothingSize)
        {
            ClothingSize = clothingSize;
        }

        public void SetEmail(Email email)
        {
            Email = email;
        }
    }
}