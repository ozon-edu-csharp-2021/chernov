namespace MerchandiseService.Models
{
    public class MerchOrder
    {
        public long Id { get; }

        public long EmployeeId { get; }

        public string Status { get; }

        public MerchOrder(long id, long employeeId, string status)
        {
            Id = id;
            EmployeeId = employeeId;
            Status = status;
        }
    }
}