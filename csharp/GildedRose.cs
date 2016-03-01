using System.Collections.Generic;
using static System.Math;

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
                UpdateQuality(Items[i]);
            }
        }

        public void UpdateQuality(Item item)
        {
            if (IsSulfuras(item)) return;

            if (IsAgedBrie(item))
            {
                IncreaseQuality(item);
                AgeItem(item);
                if (OutOfDate(item))
                    IncreaseQuality(item);
                return;
            }

            if (IsBackStagePass(item))
            {
                IncreaseQuality(item);

                if (CloseToConcert(item))
                    IncreaseQuality(item);
    
                if (EvenCloserToMethod(item))
                    IncreaseQuality(item);

                AgeItem(item);

                if (OutOfDate(item))
                    VanishQuality(item);

                return;
            }

            DecreaseQuality(item);
            AgeItem(item);
            if (OutOfDate(item))
                DecreaseQuality(item);
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
            item.Quality = Min(50, item.Quality + 1);
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = Max(0, item.Quality - 1);
        }
        
        private static void VanishQuality(Item item)
        {
            item.Quality = 0;
        }

        private static void AgeItem(Item item)
        {
            item.SellIn--;
        }

        private static bool OutOfDate(Item item)
        {
            return item.SellIn < 0;
        }

        private static bool CloseToConcert(Item item)
        {
            return item.SellIn < 11;
        }

        private static bool EvenCloserToMethod(Item item)
        {
            return item.SellIn < 6;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
    }
    
}
