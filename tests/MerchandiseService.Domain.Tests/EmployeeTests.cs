using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void SetEmail()
        {
            //Arrange 
            var employeeName = new EmployeeName("firstName1", "lastName1", "middleName1");
            var employeeEmail = Email.Create("employeeEmail1@gmail.com");
            var employee = new Employee(employeeName, employeeEmail, ClothingSize.M);
            
            //Act
            var newEmail = Email.Create("employeeEmail2@gmail.com");
            employee.SetEmail(newEmail);

            //Assert
            Assert.Equal(employee.Email, newEmail);
        }
    }
}