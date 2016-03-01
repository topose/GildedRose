namespace GildedRose
{
    class ConjuredItem : UpdatableItem
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseQuality();
            AgeItem();
        }
    }
}
