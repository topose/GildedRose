namespace GildedRose
{
    class NormalItem : UpdatableItem
    {
        public NormalItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            AgeItem();
            if (OutOfDate)
                DecreaseQuality();
        }
    }
}
