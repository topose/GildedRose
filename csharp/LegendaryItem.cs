namespace GildedRose
{
    class LegendaryItem : IUpdatableItem
    {
        private Item item;

        public LegendaryItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
