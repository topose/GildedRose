﻿using static System.Math;

namespace GildedRose
{
    class UpdatableItem : IUpdatableItem
    {
        private Item item;

        protected int SellIn => item.SellIn;

        protected UpdatableItem(Item item)
        {
            this.item = item;
        }
        
        public virtual void UpdateQuality()
        {
            if (IsSulfuras()) throw new System.Exception("should be overriden");

            if (IsAgedBrie()) throw new System.Exception("should be overriden");

            if (IsBackStagePass()) throw new System.Exception("should be overriden");

            DecreaseQuality();
            AgeItem();
            if (OutOfDate())
                DecreaseQuality();
        }

        private bool IsSulfuras()
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsAgedBrie()
        {
            return item.Name == "Aged Brie";
        }

        private bool IsBackStagePass()
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

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
