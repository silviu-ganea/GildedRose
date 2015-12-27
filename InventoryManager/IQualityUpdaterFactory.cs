using System;

namespace GildedRose
{
    internal interface IQualityUpdaterFactory
    {
        IQualityUpdater Create(string itemName);
    }

    public class QualityUpdaterFactory : IQualityUpdaterFactory
    {
        public IQualityUpdater Create(string itemName)
        {
            if(itemName == "Aged Brie")
            {
                return new AgedBrieQualityUpdater();
            }
            else if (itemName == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasQualityUpdater();
            }
            else if(itemName == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePassesQualityUpdater();
            }
            else
            {
                return new StandardItemQualityUpdater();
            }
        }
    }
}   
