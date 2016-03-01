using System.Collections.Generic;

namespace GildedRose
{
    class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items) 
        {
            this.Items = Items;
        }
        
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQualityOfSingleItem(Items[i]);
            }
        }

        private void UpdateQualityOfSingleItem(Item item)
        {
            if (IsSulfuras(item)) return;

            if (!IsAgedBrie(item) && !IsBackStagePass(item))
            {
                DecreaseQuality(item);
            }

            if (IsAgedBrie(item))
            {
                IncreaseQuality(item);
            }

            if (IsBackStagePass(item))
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (IsBackStagePass(item))
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQuality(item);
                        }
                    }
                }
            }

            AgeItem(item);

            if (item.SellIn < 0)
            {
                if (IsAgedBrie(item))
                {
                    IncreaseQuality(item);
                    return;
                }

                if (IsBackStagePass(item))
                {
                    VanishQuality(item);
                    return;
                }

                DecreaseQuality(item);
            }
        }

        private static void VanishQuality(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static bool IsBackStagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static void AgeItem(Item item)
        {
            item.SellIn--;
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
    
    public class Item
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
    }
    
}
