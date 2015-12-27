using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class InventoryManager
    {
        IList<Item> Items;
        public InventoryManager(IList<Item> Items)
        {
            this.Items = Items;
        }

        private IQualityUpdaterFactory qualityUpdaterFactory = new QualityUpdaterFactory();

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                var qualityUpdater = qualityUpdaterFactory.Create(item.Name);
                qualityUpdater.UpdateQuality(item);
            }
        }

        public Item getItem(string itemName)
        {
            var itemsWithItemName = Items.Where(i => i.Name.Equals(itemName));
            if (itemsWithItemName.Count() > 0)
            {
                return itemsWithItemName.First();
            }
            else
            {
                return null;
            }
                
        }

        public void addItem(string itemName, int itemSellIn, int itemQuality)
        {
            Item item = new Item();
            item.Name = itemName;
            item.SellIn = itemSellIn;
            item.Quality = itemQuality;
            Items.Add(item);
        }

        public int getItemQuality(string itemName)
        {
            var item = getItem(itemName);
            return item.Quality;
        }

        public int getItemSellIn(string itemName)
        {
            var item = getItem(itemName);
            return item.SellIn;
        }

        
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
