using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchOrderStatus : Enumeration
    {
        public static MerchOrderStatus Created = new(1, nameof(Created));
        public static MerchOrderStatus InQueueForIssue = new(2, nameof(InQueueForIssue));
        public static MerchOrderStatus InProgress = new(3, nameof(InProgress));
        public static MerchOrderStatus Done = new(4, nameof(Done));

        public MerchOrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}