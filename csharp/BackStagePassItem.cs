using System;

namespace GildedRose
{
    class BackStagePassItem : IUpdatableItem
    {
        private Item item;

        public BackStagePassItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            throw new NotImplementedException();
        }
    }
}
