using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using System;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchItemTests
    {
        [Fact]
        public void CreateNewMerchItemShouldPassSuccessfully()
        {
            var merchItem = new MerchItem(
                new Employee(25),
                new Employee(315),
                new Pack(PackType.WelcomePack),
                new Quantity(1));

            Assert.NotNull(merchItem);
        }

        [Fact]
        public void TryToPassNullShouldThrowTheArgumentNullException()
        {
            Assert.Throws<IncorrectQuantityException>(() =>
            {
                var merchItem = new MerchItem(
                    null,
                    new Employee(114),
                    new Pack(PackType.ConferenceSpeakerPack),
                    new Quantity(-3));
            });
        }

        [Fact]
        public void SetNegativeQuantityShouldThrowException()
        {
            Assert.Throws<IncorrectQuantityException>(() =>
            {
                var merchItem = new MerchItem(
                    new Employee(15),
                    new Employee(114),
                    new Pack(PackType.ConferenceSpeakerPack),
                    new Quantity(-3));
            });
        }

        [Fact]
        public void NewMerchItemShouldHaveCorrectValues()
        {
            var merchItem = new MerchItem(
                new Employee(113),
                new Employee(21),
                new Pack(PackType.VeteranPack),
                new Quantity(2));

            Assert.Equal(113, merchItem.Sender.Id);
            Assert.Equal(21, merchItem.Reciever.Id);
            Assert.Equal(PackType.VeteranPack, merchItem.Pack.Type);
            Assert.Equal(2, merchItem.Quantity.Value);
        }
    }
}
