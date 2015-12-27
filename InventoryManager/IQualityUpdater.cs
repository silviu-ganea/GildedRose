namespace GildedRose
{
    public interface IQualityUpdater
    {
        void UpdateQuality(Item item);
    }

    public class StandardItemQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.Quality--;
            item.SellIn--;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            if (item.SellIn <= 0)
            {
                item.SellIn = 0;
                item.Quality--;
            }
        }
    }

    public class AgedBrieQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.Quality++;
            item.SellIn--;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            if (item.SellIn < 0)
            {
                item.SellIn = 0;
            }
        }
    }

    public class SulfurasQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = 80;
            item.SellIn = 0;
        }
    }

    public class BackstagePassesQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.Quality++;

            

            if (item.SellIn <= 10)
            {
                item.Quality++;
            }

            if (item.SellIn <= 5)
            {
                item.Quality++;
            }
            if(item.Quality > 50)
            {
                item.Quality = 50;
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.SellIn = 0;
                item.Quality = 0;
            }
            
        }
    }
        
}