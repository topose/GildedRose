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

            if (IsAgedBrie(item))
            {
                IncreaseQuality(item);
                AgeItem(item);
                if (item.SellIn < 0)
                    IncreaseQuality(item);
                return;
            }

            if (IsBackStagePass(item))
            {
                IncreaseQuality(item);

                if (item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality(item);
                }
            }

            if (!IsAgedBrie(item) && !IsBackStagePass(item))
            {
                DecreaseQuality(item);
            }

            AgeItem(item);

            if (item.SellIn < 0)
            {
                if (IsBackStagePass(item))
                {
                    VanishQuality(item);
                    return;
                }

                DecreaseQuality(item);
            }
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
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

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
        
        private static void VanishQuality(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        

        private static void AgeItem(Item item)
        {
            item.SellIn--;
        }

        
    }
    
    public class Item
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
    }
    
}
