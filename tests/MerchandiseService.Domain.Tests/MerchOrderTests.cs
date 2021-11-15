using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchOrderTests
    {
        [Fact]
        public void CheckAvailability()
        {
            //Arrange 
            var employeeName = new EmployeeName("firstName1", "lastName1", "middleName1");
            var employeeEmail = Email.Create("employeeEmail1@gmail.com");
            var merchOrder = new MerchOrder(new Employee(employeeName, employeeEmail, ClothingSize.M), MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<ClothingSizeException>(() => merchOrder.CheckAvailability());
        }

        [Fact]
        public void Complete()
        {
            //Arrange 
            var employeeName = new EmployeeName("firstName1", "lastName1", "middleName1");
            var employeeEmail = Email.Create("employeeEmail1@gmail.com");
            var merchOrder = new MerchOrder(new Employee(employeeName, employeeEmail, ClothingSize.M), MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<IncorrectOrderStatusException>(() => merchOrder.Complete());
        }
        
        [Fact]
        public void MoveToQueue()
        {
            //Arrange 
            var employeeName = new EmployeeName("firstName1", "lastName1", "middleName1");
            var employeeEmail = Email.Create("employeeEmail1@gmail.com");
            var merchOrder = new MerchOrder(new Employee(employeeName, employeeEmail, ClothingSize.M), MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<IncorrectOrderStatusException>(() => merchOrder.MoveToQueue());
        }
    }
}