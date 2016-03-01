namespace GildedRose
{
    class AgedBrieItem : IUpdatableItem
    {
        private Item item;

        public AgedBrieItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
