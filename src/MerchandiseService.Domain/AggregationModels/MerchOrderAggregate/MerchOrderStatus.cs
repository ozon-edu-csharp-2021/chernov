using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchOrderStatus : Enumeration
    {
        public static MerchOrderStatus Created = new(1, nameof(Created));
        public static MerchOrderStatus InQueueForIssue = new(2, nameof(InQueueForIssue));
        public static MerchOrderStatus CheckingItemAvailability = new(3, nameof(CheckingItemAvailability));
        public static MerchOrderStatus Done = new(4, nameof(Done));

        public MerchOrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}