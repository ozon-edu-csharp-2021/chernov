using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public EmployeeName Name { get; }
        public Email Email { get; private set; }
        public ClothingSize ClothingSize { get; private set; }

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