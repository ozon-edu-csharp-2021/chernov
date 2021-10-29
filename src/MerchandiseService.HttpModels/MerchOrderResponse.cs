namespace MerchandiseService.HttpModels
{
    public class MerchOrderResponse
    {
        public long Id { get; set; }
        
        public long EmployeeId { get; set; }
        
        public string Status { get; set; }
    }
}