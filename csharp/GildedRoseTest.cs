using System.Collections.Generic;
using Xunit;


namespace GildedRose
{
    public class GildedRoseTest
    {
        [Fact]
        public void SulfurasIsInmutable()
        {
            Item sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            gildedRose = AGildedRoseWithItems(sulfuras);

            AfterDays(10);

            AssertItemsQuality(80, sulfuras);
            Assert.Equal(0, sulfuras.SellIn);
        }

        [Fact]
        public void SellInDecreasesByOneEachDay()
        {
            Item notSulfuras = new Item { Name = "notSulfuras", SellIn = 2, Quality = 0 };
            gildedRose = AGildedRoseWithItems(notSulfuras);

            AfterDays(10);

            Assert.Equal(-8, notSulfuras.SellIn);
        }

        [Fact]
        public void AgedBrieQualityIncreasesByOneEachDayBeforeSellDate()
        {
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            gildedRose = AGildedRoseWithItems(agedBrie);

            AfterDays(2);

            AssertItemsQuality(2, agedBrie);
        }

        [Fact]
        public void AgedBrieQualityIncreasesByTwoEachDayAfterSellDate()
        {
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
            gildedRose = AGildedRoseWithItems(agedBrie);

            AfterDays(2);

            AssertItemsQuality(4, agedBrie);
        }

        [Fact]
        public void QualityCannotBeMoreThanFifty()
        {
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            gildedRose = AGildedRoseWithItems(agedBrie);

            AfterDays(300);

            AssertItemsQuality(50, agedBrie);
        }

        [Fact]
        public void BackstagePassesQualityIncreasesByOneEachDayBeforeTenDaysFromSellDate()
        {
            Item backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 };
            gildedRose = AGildedRoseWithItems(backstagePasses);

            AfterDays(5);

            AssertItemsQuality(5, backstagePasses);
        }

        [Fact]
        public void BackstagePassesQualityIncreasesByTwoEachDayBetweenTenAndFiveDaysBeforeSellDate()
        {
            Item backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 };
            gildedRose = AGildedRoseWithItems(backstagePasses);

            AfterDays(7);

            AssertItemsQuality(9, backstagePasses);
        }

        [Fact]
        public void BackstagePassesQualityIncreasesByThreeEachDayBetweenFiveDaysFromSellDateAndSellDate()
        {
            Item backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 };
            gildedRose = AGildedRoseWithItems(backstagePasses);

            AfterDays(15);

            AssertItemsQuality(30, backstagePasses);
        }

        [Fact]
        public void BackstagePassesQualityIsZeroAfterTheSellDate()
        {
            Item backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            gildedRose = AGildedRoseWithItems(backstagePasses);

            AfterDays(16);

            AssertItemsQuality(0, backstagePasses);
        }

        [Fact]
        public void PerishableItemsQualityDecreasesByOneEachDayBeforeSellDate()
        {
            Item regularItem = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            gildedRose = AGildedRoseWithItems(regularItem);

            AfterDays(10);

            AssertItemsQuality(10, regularItem);
        }

        [Fact]
        public void PerishableItemsQualityDecreasesByTwoEachDayAfterSellDate()
        {
            Item perishableItem = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            gildedRose = AGildedRoseWithItems(perishableItem);

            AfterDays(15);

            AssertItemsQuality(0, perishableItem);
        }

        [Fact]
        public void PerishableItemsQualityCannotBeLessThanZero()
        {
            Item perishableItem = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            gildedRose = AGildedRoseWithItems(perishableItem);

            AfterDays(200);

            AssertItemsQuality(0, perishableItem);
        }

        [Fact]
        public void ConjuredItemsQualityDecreasesByTwoEachDayBeforeSellDate()
        {
            Item regularItem = new Item { Name = "Conjured", SellIn = 10, Quality = 21 };
            gildedRose = AGildedRoseWithItems(regularItem);

            AfterDays(10);

            AssertItemsQuality(1, regularItem);
        }

        [Fact]
        public void ConjuredItemsQualityDecreasesByFourAfterSellDate()
        {
            Item regularItem = new Item { Name = "Conjured", SellIn = 10, Quality = 41 };
            gildedRose = AGildedRoseWithItems(regularItem);

            AfterDays(15);

            AssertItemsQuality(1, regularItem);
        }

        [Fact]
        public void ConjuredItemsQualityCannotBeLessThanZero()
        {
            Item regularItem = new Item { Name = "Conjured", SellIn = 10, Quality = 41 };
            gildedRose = AGildedRoseWithItems(regularItem);

            AfterDays(16);

            AssertItemsQuality(0, regularItem);
        }

        private GildedRose gildedRose;

        private void AfterDays(int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; ++i)
            {
                gildedRose.UpdateQuality();
            }
        }

        private void AssertItemsQuality(int quality, Item item)
        {
            Assert.Equal(quality, item.Quality);
        }

        private GildedRose AGildedRoseWithItems(Item item)
        {
            return new GildedRose(new List<Item> { item });
        }

        private GildedRose AGildedRoseWithItems(IList<Item> items)
        {
            return new GildedRose(items);
        }
    }
}

