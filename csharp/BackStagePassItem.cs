using System;

namespace GildedRose
{
    class BackStagePassItem : UpdatableItem
    {
        public BackStagePassItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseQuality();

            if (CloseToConcert())
                IncreaseQuality();

            if (EvenCloserToMethod())
                IncreaseQuality();

            AgeItem();

            if (OutOfDate())
                VanishQuality();
        }

        protected bool CloseToConcert()
        {
            return base.SellIn < 11;
        }

        protected bool EvenCloserToMethod()
        {
            return base.SellIn < 6;
        }
    }
}
