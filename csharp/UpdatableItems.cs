using System;
using System.Collections;
using System.Collections.Generic;

namespace GildedRose
{
    class UpdatableItems : IEnumerable<IUpdatableItem>
    {
        private IEnumerable<Item> items;

        public UpdatableItems(IEnumerable<Item> items)
        {
            this.items = items;
        }

        public IEnumerator<IUpdatableItem> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return UpdatableItemFactory.CreateUpdatableItem(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
