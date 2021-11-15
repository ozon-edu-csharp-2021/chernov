using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchPack : Enumeration
    {
        public List<MerchItemType> MerchItems;

        public static MerchPack WelcomePack = new MerchPack(10, nameof(WelcomePack), new List<MerchItemType>
        {
            MerchItemType.Pen,
            MerchItemType.Notepad
        });

        public static MerchPack StarterPack = new MerchPack(20, nameof(StarterPack), new List<MerchItemType>
        {
            MerchItemType.Pen,
            MerchItemType.Notepad,
            MerchItemType.Socks,
            MerchItemType.TShirt
        });

        public static MerchPack ConferenceListenerPack = new MerchPack(30, nameof(ConferenceListenerPack),
            new List<MerchItemType>
            {
                MerchItemType.TShirt
            });

        public static MerchPack ConferenceSpeakerPack = new MerchPack(40, nameof(ConferenceSpeakerPack),
            new List<MerchItemType>
            {
                MerchItemType.TShirt,
                MerchItemType.Sweatshirt
            });

        public static MerchPack VeteranPack = new MerchPack(50, nameof(VeteranPack), new List<MerchItemType>
        {
            MerchItemType.Pen,
            MerchItemType.Notepad,
            MerchItemType.Socks,
            MerchItemType.Sweatshirt,
            MerchItemType.TShirt,
            MerchItemType.Bag
        });

        public MerchPack(int id, string name, List<MerchItemType> merchItems) : base(id, name)
        {
            MerchItems = merchItems;
        }
    }
}