namespace MerchandiseService.HttpModels
{
    public class MerchOrderPostViewModel
    {
        public long EmployeeId { get; set; }
        
        public int MerchPack { get; set; }
        
        public int? ClothingSize { get; set; }
    }
}