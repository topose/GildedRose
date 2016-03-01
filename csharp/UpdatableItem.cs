namespace GildedRose
{
    class UpdatableItem : IUpdatableItem
    {
        private Item item;

        protected UpdatableItem(Item item)
        {
            this.item = item;
        }


        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}
