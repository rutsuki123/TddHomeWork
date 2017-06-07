using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// ShoppingCartTest 的摘要說明
    /// </summary>
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void 第一集買了一本_其他都沒買_價格應為100_X_1等於_100()
        {
            // arrange
            var order = this.GetOrder(1, 0, 0, 0, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 100;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 第一集買了一本_第二集也買了一本_價格應為_100_X_2_X_0點95_等於_190()
        {
            // arrange
            var order = this.GetOrder(1, 1, 0, 0, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 190;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一二三集各買了一本_價格應為_100_X_3_X_0點9_等於_270()
        {
            // arrange
            var order = this.GetOrder(1, 1, 1, 0, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 270;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一二三四集各買了一本_價格應為100_X_4_X_0點8_等於_320()
        {
            // arrange
            var order = this.GetOrder(1, 1, 1, 1, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 320;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一次買了整套_一二三四五集各買了一本_價格應為100_X_5_X_0點75_等於_375()
        {
            // arrange
            var order = this.GetOrder(1, 1, 1, 1, 1);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 375;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一二集各買了一本_第三集買了兩本_價格應為100_X_3_X_0點9_加_100_等於_370()
        {
            // arrange
            var order = this.GetOrder(1, 1, 2, 0, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 370;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 第一集買了一本_第二三集各買了兩本_價格應為100_X_3_X_0點9_加_100_X_2_X_0點95_等於_460()
        {
            // arrange
            var order = this.GetOrder(1, 2, 2, 0, 0);

            // actual
            var actual = order.Bill();

            // assert
            var expected = 460;
            Assert.AreEqual(actual, expected);
        }

        private Order GetOrder(int oneCount, int twoCount, int threeCount, int fourCount, int fiveCount)
        {
            return new Order()
            {
                VolumeOneCount = oneCount,
                VolumeTwoCount = twoCount,
                VolumeThreeCount = threeCount,
                VolumeFourCount = fourCount,
                VolumeFiveCount = fiveCount,
            };
        }
    }


    public class Order
    {
        public int VolumeOneCount { get; set; }

        public int VolumeTwoCount { get; set; }

        public int VolumeThreeCount { get; set; }

        public int VolumeFourCount { get; set; }

        public int VolumeFiveCount { get; set; }
    }

    public static class EnumerableExtension
    {
        public static Order Bill(this Order source)
        {
            throw new NotImplementedException();
        }
    }
}
