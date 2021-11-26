using System;

namespace MerchandiseService.Infrastructure.Repositories.Models
{
    public class MerchOrder
    {
        public long Id { get; set; }

        public int Status { get; set; }
        
        public long EmployeeId { get; set; }
        
        public string MiddleName { get; set; }

        public int MerchPack { get; set; }
        
        public DateTime DateOfIssue { get; set; }
    }
}