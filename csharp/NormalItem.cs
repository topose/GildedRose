namespace GildedRose
{
    class NormalItem : IUpdatableItem
    {
        private Item item;

        public NormalItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
