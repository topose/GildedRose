namespace GildedRose
{
    class LegendaryItem : UpdatableItem
    {
        public LegendaryItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            // legendary items never change its quality or sellin.            
        }
    }
}
