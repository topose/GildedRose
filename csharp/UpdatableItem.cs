using static System.Math;

namespace GildedRose
{
    abstract class UpdatableItem : IUpdatableItem
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        private Item item;

        protected int SellIn => item.SellIn;

        protected UpdatableItem(Item item)
        {
            this.item = item;
        }

        public abstract void UpdateQuality();

        protected void IncreaseQuality()
        {
            item.Quality = Min(MaxQuality, item.Quality + 1);
        }

        protected void DecreaseQuality()
        {
            item.Quality = Max(MinQuality, item.Quality - 1);
        }

        protected void VanishQuality()
        {
            item.Quality = 0;
        }

        protected void AgeItem()
        {
            item.SellIn--;
        }

        protected bool OutOfDate => item.SellIn < 0;
    }
}
