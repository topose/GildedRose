using System;
using System.Collections;
using System.Collections.Generic;

namespace GildedRose
{
    class UpdatableItems : IEnumerable<UpdatableItem>
    {
        private IEnumerable<Item> items;

        public UpdatableItems(IEnumerable<Item> items)
        {
            this.items = items;
        }

        public IEnumerator<UpdatableItem> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return null;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
