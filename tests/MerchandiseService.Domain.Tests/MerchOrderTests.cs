using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchOrderTests
    {
        [Fact]
        public void CheckAvailability()
        {
            //Arrange 
            var merchOrder = new MerchOrder(0, MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<ClothingSizeException>(() => merchOrder.CheckAvailability());
        }
        
        [Fact]
        public void CheckAvailabilityMerchPackWithoutSize()
        {
            //Arrange 
            var merchOrder = new MerchOrder(0, MerchPack.WelcomePack);
            
            //Act
            merchOrder.CheckAvailability();
            
            //Assert
            Assert.Equal(merchOrder.Status, MerchOrderStatus.InProgress);
        }
        
        [Fact]
        public void Complete()
        {
            //Arrange 
            var merchOrder = new MerchOrder(0, MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<IncorrectOrderStatusException>(() => merchOrder.Complete());
        }
        
        [Fact]
        public void MoveToQueue()
        {
            //Arrange 
            var merchOrder = new MerchOrder(0, MerchPack.VeteranPack);
            //Act
            
            //Assert
            Assert.Throws<IncorrectOrderStatusException>(() => merchOrder.MoveToQueue());
        }
    }
}