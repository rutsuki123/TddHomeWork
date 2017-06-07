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
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100}
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 100;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 第一集買了一本_第二集也買了一本_價格應為_100_X_2_X_0點95_等於_190()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100}
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 190;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一二三集各買了一本_價格應為_100_X_3_X_0點9_等於_270()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 3,Price = 100},
            };
            // actual
            var actual = order.Bill();

            // assert
            var expected = 270;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void 一二三四集各買了一本_價格應為100_X_4_X_0點8_等於_320()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 3,Price = 100},
                new Book(){Volume = 4,Price = 100},
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 320;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(actual, expected);
        }

        //[TestMethod]
        //public void 一次買了整套_一二三四五集各買了一本_價格應為100_X_5_X_0點75_等於_375()
        //{
        //    // arrange
        //    var order = new List<Book>()
        //    {
        //        new Book(){Volume = 1,Price = 100},
        //        new Book(){Volume = 2,Price = 100},
        //        new Book(){Volume = 3,Price = 100},
        //        new Book(){Volume = 4,Price = 100},
        //        new Book(){Volume = 5,Price = 100},
        //    };

        //    // actual
        //    var actual = order.Bill();

        //    // assert
        //    var expected = 375;
        //    Assert.AreEqual(actual, expected);
        //}

        //[TestMethod]
        //public void 一二集各買了一本_第三集買了兩本_價格應為100_X_3_X_0點9_加_100_等於_370()
        //{
        //    // arrange
        //    var order = new List<Book>()
        //    {
        //        new Book(){Volume = 1,Price = 100},
        //        new Book(){Volume = 2,Price = 100},
        //        new Book(){Volume = 3,Price = 100},
        //        new Book(){Volume = 3,Price = 100},
        //    };

        //    // actual
        //    var actual = order.Bill();

        //    // assert
        //    var expected = 370;
        //    Assert.AreEqual(actual, expected);
        //}

        //[TestMethod]
        //public void 第一集買了一本_第二三集各買了兩本_價格應為100_X_3_X_0點9_加_100_X_2_X_0點95_等於_460()
        //{
        //    // arrange
        //    var order = new List<Book>()
        //    {
        //        new Book(){Volume = 1,Price = 100},
        //        new Book(){Volume = 2,Price = 100},
        //        new Book(){Volume = 2,Price = 100},
        //        new Book(){Volume = 3,Price = 100},
        //        new Book(){Volume = 3,Price = 100},
        //    };

        //    // actual
        //    var actual = order.Bill();

        //    // assert
        //    var expected = 460;
        //    Assert.AreEqual(actual, expected);
        //}
    }


    public class Book
    {
        public int Volume { get; set; }

        public decimal Price { get; set; }
    }

    public static class EnumerableExtension
    {
        public static decimal Bill(this List<Book> books)
        {
            var booksGroup = books.GroupBy(r => r.Volume).Where(r => r.Any());
            if (books.Count == 1)
            {
                return books.Sum(r => r.Price);
            }
            if (booksGroup.Count() == 2)
            {
                return books.Sum(r => r.Price) * (decimal)0.95;
            }
            if (booksGroup.Count() == 3)
            {
                return books.Sum(r => r.Price) * (decimal)0.9;
            }
            if (booksGroup.Count() == 4)
            {
                return books.Sum(r => r.Price) * (decimal)0.8;
            }
            throw new NotImplementedException();
        }
    }
}
