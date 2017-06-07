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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一次買了整套_一二三四五集各買了一本_價格應為100_X_5_X_0點75_等於_375()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 3,Price = 100},
                new Book(){Volume = 4,Price = 100},
                new Book(){Volume = 5,Price = 100},
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 375;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 一二集各買了一本_第三集買了兩本_價格應為100_X_3_X_0點9_加_100_等於_370()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 3,Price = 100},
                new Book(){Volume = 3,Price = 100},
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 370;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 第一集買了一本_第二三集各買了兩本_價格應為100_X_3_X_0點9_加_100_X_2_X_0點95_等於_460()
        {
            // arrange
            var order = new List<Book>()
            {
                new Book(){Volume = 1,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 2,Price = 100},
                new Book(){Volume = 3,Price = 100},
                new Book(){Volume = 3,Price = 100},
            };

            // actual
            var actual = order.Bill();

            // assert
            var expected = 460;
            Console.WriteLine($"{actual};{expected}");
            Assert.AreEqual(expected, actual);
        }
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
            // 先依照冊來分組(因為折扣是按照有幾本不同的)
            var booksGroup = books.GroupBy(r => r.Volume).ToList();

            // 從分組的組別數量取得優惠折扣
            var discount = GetPreferential(booksGroup.Count());

            // 總價錢
            var totalPrice = default(decimal);

            // 計算這組的總金額
            var oneGroupPrice = booksGroup.SelectMany(r => r.Take(1)).Select(r => r.Price).Aggregate((a, b) => a + b);
            totalPrice += oneGroupPrice * discount;

            // 每組拿掉一筆, 如果還有項目, 代表還可以繼續計算金額
            var temp = booksGroup.SelectMany(r => r.Skip(1)).ToList();
            if (temp.Any())
            {
                totalPrice += temp.Bill();
            }
            
            // 結果
            return totalPrice;
        }

        private static decimal GetPreferential(int count)
        {
            switch (count)
            {
                case 1:
                    return 1;
                case 2:
                    return (decimal)0.95;
                case 3:
                    return (decimal)0.90;
                case 4:
                    return (decimal)0.80;
                case 5:
                    return (decimal)0.75;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
