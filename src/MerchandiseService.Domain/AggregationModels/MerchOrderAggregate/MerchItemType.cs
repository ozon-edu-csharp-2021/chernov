using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchItemType : Enumeration
    {
        public static MerchItemType TShirt = new(1, nameof(TShirt));
        public static MerchItemType Sweatshirt = new(2, nameof(Sweatshirt));
        public static MerchItemType Notepad = new(3, nameof(Notepad));
        public static MerchItemType Bag = new(4, nameof(Bag));
        public static MerchItemType Pen = new(5, nameof(Pen));
        public static MerchItemType Socks = new(6, nameof(Socks));

        public MerchItemType(int id, string name) : base(id, name)
        {
        }
    }
}