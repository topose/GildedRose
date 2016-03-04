namespace GildedRose
{
    class UpdatableItemFactory
    {
        public static IUpdatableItem CreateUpdatableItem(Item item)
        {
            if (IsLegendaryItem(item)) return new LegendaryItem(item);

            if (IsAgedBrie(item)) return new AgedBrieItem(item);

            if (IsBackStagePass(item)) return new BackStagePassItem(item);

            if (IsConjured(item)) return new ConjuredItem(item);

            return new NormalItem(item);
        }

        private static bool IsLegendaryItem(Item item) => item.Name == "Sulfuras, Hand of Ragnaros";

        private static bool IsAgedBrie(Item item) => item.Name == "Aged Brie";

        private static bool IsBackStagePass(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";

        private static bool IsConjured(Item item) => item.Name == "Conjured";
    }
}
