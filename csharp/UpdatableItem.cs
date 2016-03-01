using static System.Math;

namespace GildedRose
{
    abstract class UpdatableItem : IUpdatableItem
    {
        private Item item;

        protected int SellIn => item.SellIn;

        protected UpdatableItem(Item item)
        {
            this.item = item;
        }

        public abstract void UpdateQuality();

        protected void IncreaseQuality()
        {
            item.Quality = Min(50, item.Quality + 1);
        }

        protected void DecreaseQuality()
        {
            item.Quality = Max(0, item.Quality - 1);
        }

        protected void VanishQuality()
        {
            item.Quality = 0;
        }

        protected void AgeItem()
        {
            item.SellIn--;
        }

        protected bool OutOfDate()
        {
            return item.SellIn < 0;
        }
    }
}
