using System;
using System.Collections;
using System.Collections.Generic;

namespace GildedRose
{
    class UpdatableItems : IEnumerable<IUpdatableItem>
    {
        private IEnumerable<Item> items;

        public UpdatableItems(IEnumerable<Item> items)
        {
            this.items = items;
        }

        public IEnumerator<IUpdatableItem> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return CreateUpdatableItem(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IUpdatableItem CreateUpdatableItem(Item item)
        {
            if (IsLegendaryItem(item)) return new LegendaryItem(item);

            if (IsAgedBrie(item)) return new AgedBrieItem(item);

            if (IsBackStagePass(item)) return new BackStagePassItem(item);

            if (IsConjured(item)) return new ConjuredItem(item);

            return new NormalItem(item);
        }

        private static bool IsLegendaryItem(Item item)
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

        private static bool IsConjured(Item item)
        {
            return item.Name == "Conjured";
        }
    }
}
