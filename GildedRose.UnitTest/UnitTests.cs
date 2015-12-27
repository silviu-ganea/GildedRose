using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRose
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemGetAndAddTest()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());
            Item sausageItem = new Item { Name = "Sausage", SellIn = 10, Quality = 30 };

            //Do
            inventoryManager.addItem(sausageItem.Name, sausageItem.SellIn, sausageItem.Quality);
            Item newItem = inventoryManager.getItem("Sausage");

            //Assert
            Assert.AreEqual(sausageItem.Name,newItem.Name);
            Assert.AreEqual(sausageItem.SellIn, newItem.SellIn);
            Assert.AreEqual(sausageItem.Quality, newItem.Quality);
        }

        [TestMethod]
        public void StandardItemUpdateTest()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Sausage", 10, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Sausage"), 9);
            Assert.AreEqual(inventoryManager.getItemQuality("Sausage"), 29);
        }

        [TestMethod]
        public void AgedBrieTest()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Aged Brie", 10, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Aged Brie"), 9);
            Assert.AreEqual(inventoryManager.getItemQuality("Aged Brie"), 31);
        }

        [TestMethod]
        public void SulfurasTest()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Sulfuras, Hand of Ragnaros", 10, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Sulfuras, Hand of Ragnaros"), 0);
            Assert.AreEqual(inventoryManager.getItemQuality("Sulfuras, Hand of Ragnaros"), 80);
        }

        [TestMethod]
        public void BackstagePassesQualityRate1()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 11, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Backstage passes to a TAFKAL80ETC concert"), 10);
            Assert.AreEqual(inventoryManager.getItemQuality("Backstage passes to a TAFKAL80ETC concert"), 31);
        }

        [TestMethod]
        public void BackstagePassesQualityRate2()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 10, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Backstage passes to a TAFKAL80ETC concert"), 9);
            Assert.AreEqual(inventoryManager.getItemQuality("Backstage passes to a TAFKAL80ETC concert"), 32);
        }

        [TestMethod]
        public void BackstagePassesQualityRate3()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 5, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemSellIn("Backstage passes to a TAFKAL80ETC concert"), 4);
            Assert.AreEqual(inventoryManager.getItemQuality("Backstage passes to a TAFKAL80ETC concert"), 33);
        }

        [TestMethod]
        public void SellInIsNeverNegative()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Blue Berries", 0, 30);
            inventoryManager.addItem("Aged brie", 0, 30);
            inventoryManager.addItem("Sulfuras, Hand of Ragnaros", 0, 30);
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 0, 30);

            inventoryManager.UpdateQuality();

            //Assert
            Assert.IsFalse(inventoryManager.getItemSellIn("Blue Berries") < 0);
            Assert.IsFalse(inventoryManager.getItemSellIn("Aged brie") < 0);
            Assert.IsFalse(inventoryManager.getItemSellIn("Sulfuras, Hand of Ragnaros") < 0);
            Assert.IsFalse(inventoryManager.getItemSellIn("Backstage passes to a TAFKAL80ETC concert") < 0);
        }

        [TestMethod]
        public void QualityIsNeverMoreThan50()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Blue Berries", 0, 51);
            inventoryManager.addItem("Aged brie", 0, 51);
            inventoryManager.addItem("Sulfuras, Hand of Ragnaros", 0, 51);
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 0, 51);

            inventoryManager.UpdateQuality();

            //Assert
            Assert.IsFalse(inventoryManager.getItemQuality("Blue Berries") > 50);
            Assert.IsFalse(inventoryManager.getItemQuality("Aged brie") > 50);
            Assert.AreEqual(inventoryManager.getItemQuality("Sulfuras, Hand of Ragnaros"), 80);
            Assert.IsFalse(inventoryManager.getItemQuality("Backstage passes to a TAFKAL80ETC concert") > 50);
        }

        [TestMethod]
        public void QualityDegradesTwiceAsFastBackstagePasses()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Backstage passes to a TAFKAL80ETC concert", 0, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemQuality("Backstage passes to a TAFKAL80ETC concert"), 0);
        }
        [TestMethod]
        public void QualityDegradesTwiceAsFastStandardItem()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Blue Berries", 0, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemQuality("Blue Berries"), 28);
        }
        [TestMethod]
        public void QualityDegradesTwiceAsFastAgedBrie()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Aged Brie", 0, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemQuality("Aged Brie"), 31);
        }
        [TestMethod]
        public void QualityDegradesTwiceAsFastSulfuras()
        {
            //Create
            InventoryManager inventoryManager = new InventoryManager(new List<Item>());

            //Do
            inventoryManager.addItem("Sulfuras, Hand of Ragnaros", 0, 30);
            inventoryManager.UpdateQuality();

            //Assert
            Assert.AreEqual(inventoryManager.getItemQuality("Sulfuras, Hand of Ragnaros"), 80);
        }
    }
}
