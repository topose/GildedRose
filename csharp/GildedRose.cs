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
                UpdateQuality(Items[i]);
            }
        }

        private IUpdatableItem GetUpdatableItem(Item item)
        {
            if (IsSulfuras(item)) return new LegendaryItem(item);

            if (IsAgedBrie(item)) return new AgedBrieItem(item);

            if (IsBackStagePass(item)) return new BackStagePassItem(item);

            return new NormalItem(item);
        }

        private void UpdateQuality(Item item)
        {
            GetUpdatableItem(item).UpdateQuality();   
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
    }

    public class Item
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
    }
    
}
