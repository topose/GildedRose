﻿namespace GildedRose
{
    class AgedBrieItem : UpdatableItem
    {
        public AgedBrieItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseQuality();
            AgeItem();
            if (OutOfDate)
                IncreaseQuality();
        }
    }
}
