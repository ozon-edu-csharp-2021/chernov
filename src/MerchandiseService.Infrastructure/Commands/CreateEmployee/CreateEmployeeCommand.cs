using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public string Email { get; set; }
        
        public int ClothingSize { get; set; }
    }
}